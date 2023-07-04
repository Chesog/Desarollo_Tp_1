using System;
using UnityEngine;

public class Enemy_State_Machine : State_Machine
{
    [SerializeField] Enemy_Component enemy;

    [SerializeField] Enemy_Idle_State idle_State;
    [SerializeField] Enemy_Move_State move_State;
    [SerializeField] Enemy_Attack_State attack_State;
    [SerializeField] Enemy_Hit_State hit_State;
    [SerializeField] Enemy_Dead_State dead_State;

    protected override void OnEnable()
    {
        idle_State = new Enemy_Idle_State(this,enemy);
        move_State = new Enemy_Move_State(this,enemy);
        attack_State = new Enemy_Attack_State(this,enemy);
        hit_State = new Enemy_Hit_State(this,enemy);
        dead_State = new Enemy_Dead_State(this,enemy);

        idle_State.AddStateTransitions(nameof(Enemy_Move_State), move_State);
        idle_State.AddStateTransitions(nameof(Enemy_Hit_State), hit_State);
        idle_State.AddStateTransitions(nameof(Enemy_Dead_State), dead_State);

        move_State.AddStateTransitions(nameof(Enemy_Idle_State), idle_State);
        move_State.AddStateTransitions(nameof(Enemy_Attack_State), attack_State);
        move_State.AddStateTransitions(nameof(Enemy_Hit_State), hit_State);
        move_State.AddStateTransitions(nameof(Enemy_Dead_State), dead_State);

        attack_State.AddStateTransitions(nameof(Enemy_Idle_State), idle_State);
        attack_State.AddStateTransitions(nameof(Enemy_Hit_State), hit_State);
        attack_State.AddStateTransitions(nameof(Enemy_Dead_State), dead_State);

        hit_State.AddStateTransitions(nameof(Enemy_Idle_State), idle_State);
        hit_State.AddStateTransitions(nameof(Enemy_Move_State), move_State);
        hit_State.AddStateTransitions(nameof(Enemy_Dead_State), dead_State);

        dead_State.AddStateTransitions(nameof(Enemy_Idle_State), idle_State);
        base.OnEnable();
    }

    protected override State GetInitialState()
    {
        base.GetInitialState();
        return idle_State;
    }
}
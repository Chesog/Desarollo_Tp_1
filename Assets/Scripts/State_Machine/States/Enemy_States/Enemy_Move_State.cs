using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move_State : Enemy_Base_State
{
    public Enemy_Move_State(Enemy_State_Machine enemySM, Enemy_Component enemy) : base(nameof(Enemy_Move_State), enemySM, enemy) { }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void AddStateTransitions(string transitionName, State transitionState)
    {
        base.AddStateTransitions(transitionName, transitionState);
    }
}

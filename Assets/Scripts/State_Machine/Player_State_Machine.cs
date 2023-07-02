using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Player_State_Machine : State_Machine
{
    [SerializeField] public Player_Component player;

    [SerializeField] private Player_Idle_State idleState;
    [SerializeField] private Player_Movement_State moveState;

    protected override void OnEnable()
    {
        idleState = new Player_Idle_State(this, player);
        moveState = new Player_Movement_State(this, player);

        idleState.AddStateTransitions(nameof(Player_Movement_State), moveState);
        moveState.AddStateTransitions(nameof(Player_Idle_State), idleState);
        base.OnEnable();
    }

    protected override State GetInitialState()
    {
        return idleState;
    }
}

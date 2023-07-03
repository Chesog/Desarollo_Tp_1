using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Player_State_Machine : State_Machine
{
    [SerializeField] public Player_Component player;

    [SerializeField] private Player_Idle_State idleState;
    [SerializeField] private Player_Movement_State moveState;
    [SerializeField] private Player_Jump_State jumpState;
    [SerializeField] private Player_Attack_State attackState;
    [SerializeField] private Player_Block_State blockState;

    protected override void OnEnable()
    {
        idleState = new Player_Idle_State(this, player);
        moveState = new Player_Movement_State(this, player);
        jumpState = new Player_Jump_State(this, player);
        attackState = new Player_Attack_State(this, player);
        blockState = new Player_Block_State(this, player);

        idleState.AddStateTransitions(nameof(Player_Movement_State), moveState);
        idleState.AddStateTransitions(nameof(Player_Jump_State), jumpState);
        idleState.AddStateTransitions(nameof(Player_Attack_State), attackState);
        idleState.AddStateTransitions(nameof(Player_Block_State), blockState);

        moveState.AddStateTransitions(nameof(Player_Idle_State), idleState);
        moveState.AddStateTransitions(nameof(Player_Jump_State), jumpState);
        moveState.AddStateTransitions(nameof(Player_Attack_State), attackState);
        moveState.AddStateTransitions(nameof(Player_Block_State), blockState);

        jumpState.AddStateTransitions(nameof(Player_Movement_State), moveState);
        jumpState.AddStateTransitions(nameof(Player_Idle_State), idleState);

        attackState.AddStateTransitions(nameof(Player_Idle_State), idleState);
        attackState.AddStateTransitions(nameof(Player_Movement_State), moveState);
        attackState.AddStateTransitions(nameof(Player_Jump_State), jumpState);
        attackState.AddStateTransitions(nameof(Player_Block_State), blockState);

        blockState.AddStateTransitions(nameof(Player_Idle_State), idleState);
        blockState.AddStateTransitions(nameof(Player_Movement_State), moveState);
        blockState.AddStateTransitions(nameof(Player_Jump_State), jumpState);
        blockState.AddStateTransitions(nameof(Player_Attack_State), attackState);

        base.OnEnable();
    }

    protected override State GetInitialState()
    {
        return idleState;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(player.feet_Pivot.position, Vector3.down * player.maxDistance);
    }
}

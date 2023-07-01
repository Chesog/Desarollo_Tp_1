using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement_State : State
{
    public Player_Movement_State(Movement_State_Machine movementSM) : base(nameof(Player_Movement_State), movementSM) { }
    private Movement_State_Machine machine;

    public override void OnEnter()
    {
        base.OnEnter();
        machine = ((Movement_State_Machine)state_Machine);
        machine.Player_Input.OnPlayerMove += Player_Input_OnPlayerMove;
    }

    private void Player_Input_OnPlayerMove(Vector2 newMovement)
    {
        machine.player_Movement = new Vector3(newMovement.x,0f,newMovement.y).normalized;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (machine.player_Movement == Vector3.zero)
            base.state_Machine.SetState(base.transitions[nameof(Player_Idle_State)]);
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        float targetAngle = Mathf.Atan2(machine.player_Movement.x, machine.player_Movement.z) * Mathf.Rad2Deg + machine.player_Camera.eulerAngles.y;

        machine.lastAngle = targetAngle;

        float angle = Mathf.SmoothDampAngle(machine.player_Transform.eulerAngles.y, targetAngle, ref machine.turn_Smooth_Velocity, machine.setings.turnSmoothTime);

        machine.player_Transform.rotation = Quaternion.Euler(0f, angle, 0f);

        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

        machine.player_Rigid_Body.velocity = moveDir.normalized * machine.setings.speed + Vector3.up * machine.player_Rigid_Body.velocity.y;
    }

    public override void AddStateTransitions(string transitionName, State transitionState)
    {
        base.AddStateTransitions(transitionName, transitionState);
        transitions.Add(transitionName, transitionState);
    }
}

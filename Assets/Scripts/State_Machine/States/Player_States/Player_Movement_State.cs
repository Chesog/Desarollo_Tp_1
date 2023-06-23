using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement_State : State
{
    public Player_Movement_State(Movement_State_Machine movementSM) : base(nameof(Player_Movement_State), movementSM) { }

    public override void OnEnter()
    {
        base.OnEnter();
        ((Movement_State_Machine)state_Machine).player_Movement = Vector3.zero;
        ((Movement_State_Machine)state_Machine).Player_Input.OnPlayerMove += Player_Input_OnPlayerMove;
        Debug.Log("Abemus Movement");
    }

    private void Player_Input_OnPlayerMove(Vector2 newMovement)
    {
        ((Movement_State_Machine)state_Machine).player_Movement = newMovement;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (((Movement_State_Machine)state_Machine).player_Movement == Vector3.zero)
            base.state_Machine.SetState(base.transitions[nameof(Player_Idle_State)]);
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        float targetAngle = Mathf.Atan2(((Movement_State_Machine)state_Machine).player_Movement.x, ((Movement_State_Machine)state_Machine).player_Movement.z) * Mathf.Rad2Deg + ((Movement_State_Machine)state_Machine).player_Camera.eulerAngles.y;
        ((Movement_State_Machine)state_Machine).lastAngle = targetAngle;
        float angle = Mathf.SmoothDampAngle(((Movement_State_Machine)state_Machine).player_Transform.eulerAngles.y, targetAngle, ref ((Movement_State_Machine)state_Machine).turn_Smooth_Velocity, ((Movement_State_Machine)state_Machine).setings.turnSmoothTime);
        ((Movement_State_Machine)state_Machine).player_Transform.rotation = Quaternion.Euler(0f, angle, 0f);

        Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

        ((Movement_State_Machine)state_Machine).player_Rigid_Body.velocity = moveDir.normalized * ((Movement_State_Machine)state_Machine).setings.speed + Vector3.up * ((Movement_State_Machine)state_Machine).player_Rigid_Body.velocity.y;
    }

    public override void AddStateTransitions(string transitionName, State transitionState)
    {
        base.AddStateTransitions(transitionName, transitionState);
        transitions.Add(transitionName, transitionState);
    }
}

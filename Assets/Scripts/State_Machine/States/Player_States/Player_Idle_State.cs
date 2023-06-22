using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Idle_State : State
{
    private Vector2 movement;

    public Player_Idle_State(Movement_State_Machine movementSM) : base(nameof(Player_Idle_State), movementSM) { }

    public override void OnEnter()
    {
        base.OnEnter();
        movement = Vector2.zero;
        ((Movement_State_Machine)state_Machine).Player_Input.OnPlayerMove += OnPlayerMove;
        Debug.Log("Abemus Idle");
    }

    private void OnPlayerMove(Vector2 newMovement) 
    {
        movement = newMovement;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (movement != Vector2.zero)
            base.state_Machine.SetState(base.transitions[nameof(Player_Movement_State)]);
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }

    public override void AddStateTransitions(string transitionName, State transitionState)
    {
        base.AddStateTransitions(transitionName, transitionState);
        transitions.Add(transitionName,transitionState);
    }
}

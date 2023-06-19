using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Idle : BaseState
{
    [SerializeField] private PlayerInput input;
    private Vector3 movement;

    public Player_Idle(Movement_State_Machine movementSM) : base(nameof(Player_Idle), movementSM) { }

    public override void OnEnter()
    {
        base.OnEnter();
        movement = Vector3.zero;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        //movement = input.GetValue
    }
}

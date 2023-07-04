using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[Obsolete]public class Movement_State_Machine : State_Machine
{
    [HideInInspector]
    public Player_Idle_State idleState;
    [HideInInspector]
    public Player_Movement_State movement_State;
    [Obsolete] public Rigidbody player_Rigid_Body;
   // [Obsolete] [SerializeField] public Player_Input_Manager Player_Input;
    [Obsolete] [SerializeField] public Player_Setings setings;
    [Obsolete] [SerializeField] public Vector3 player_Movement;
    [Obsolete] [SerializeField] public Transform player_Transform;
    [Obsolete] [SerializeField] public Transform player_Camera;
    [Obsolete] [SerializeField] public float turn_Smooth_Velocity;
    [Obsolete] [SerializeField] public float lastAngle;
    protected override void OnEnable()
    {
        //idleState = new Player_Idle_State(this);
        //movement_State = new Player_Movement_State(this);
        idleState.AddStateTransitions(nameof(Player_Movement_State),movement_State);
        movement_State.AddStateTransitions(nameof(Player_Idle_State), idleState);
       // Player_Input = GetComponent<Player_Input_Manager>();
        player_Rigid_Body = GetComponent<Rigidbody>();
        base.OnEnable();
    }

    protected override State GetInitialState()
    {
        return idleState;
    }
}

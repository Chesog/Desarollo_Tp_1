using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement_State_Machine : State_Machine
{
    [HideInInspector]
    public Player_Idle_State idleState;
    [HideInInspector]
    public Player_Movement_State movement_State;
    public Rigidbody player_Rigid_Body;
    [SerializeField] public Player_Input_Manager Player_Input;
    [SerializeField] public Player_Setings setings;
    [SerializeField] public Vector3 player_Movement;
    [SerializeField] public Transform player_Transform;
    [SerializeField] public Transform player_Camera;
    [SerializeField] public float turn_Smooth_Velocity;
    [SerializeField] public float lastAngle;

    protected override void OnEnable()
    {
        idleState = new Player_Idle_State(this);
        movement_State = new Player_Movement_State(this);
        idleState.AddStateTransitions(nameof(Player_Movement_State),movement_State);
        movement_State.AddStateTransitions(nameof(Player_Idle_State), idleState);
        Player_Input = GetComponent<Player_Input_Manager>();
        player_Rigid_Body = GetComponent<Rigidbody>();
        base.OnEnable();
    }

    protected override State GetInitialState()
    {
        return idleState;
    }
}

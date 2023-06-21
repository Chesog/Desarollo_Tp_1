using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_State_Machine : State_Machine
{
    public Player_Idle idleState;

    private void OnEnable()
    {
        idleState = new Player_Idle(this);
    }

    protected override BaseState GetInitialState()
    {
        return idleState;
    }
}

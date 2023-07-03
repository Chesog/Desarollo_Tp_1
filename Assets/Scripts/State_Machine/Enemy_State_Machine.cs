using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Enemy_State_Machine : State_Machine
{
    [SerializeField] Enemy_Component enemy;

    [SerializeField] Enemy_Idle_State idle_State;
    [SerializeField] Enemy_Move_State move_State;
    [SerializeField] Enemy_Attack_State attack_State;
    [SerializeField] Enemy_Dead_State dead_State;

    private void OnEnable()
    {
        
    }

    protected override State GetInitialState()
    {
        return idle_State;
    }
}

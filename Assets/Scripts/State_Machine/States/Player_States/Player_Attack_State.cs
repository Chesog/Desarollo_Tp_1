using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack_State : Player_Base_State
{
    private float attkCounter;
    private float attkTimer;
    public Player_Attack_State(Player_State_Machine playerSM, Player_Component player) : base(nameof(Player_Attack_State), playerSM, player) { }

    public override void OnEnter() 
    {
        base.OnEnter();
        player.anim.Play("Sword And Shield Slash");

        attkCounter = 1.5f;
        attkTimer = 0.0f;

        player.input.OnPlayerAttack += Input_OnPlayerAttack;
        player.input.OnPlayerMove += Input_OnPlayerMove;
        player.input.OnPlayerJump += Input_OnPlayerJump;
    }

    private void Input_OnPlayerJump(bool obj)
    {
        base.state_Machine.SetState(base.transitions[nameof(Player_Jump_State)]);
    }

    private void Input_OnPlayerMove(Vector2 obj)
    {
        base.state_Machine.SetState(base.transitions[nameof(Player_Movement_State)]);
    }

    private void Input_OnPlayerAttack(bool obj)
    {
        player.anim.Play("Attacking");
    }

    public override void UpdateLogic()
    {
        if (attkTimer >= attkCounter)
        {
            base.state_Machine.SetState(base.transitions[nameof(Player_Idle_State)]);
        }
        else
        {
            attkTimer += Time.deltaTime;
        }
    }

    public override void UpdatePhysics()
    {

    }

    public override void OnExit()
    {
        player.input.OnPlayerAttack -= Input_OnPlayerAttack;
        player.input.OnPlayerMove -= Input_OnPlayerMove;
        player.input.OnPlayerJump -= Input_OnPlayerJump;
    }

    public virtual void AddStateTransitions(string transitionName, State transitionState)
    {
        base.AddStateTransitions(transitionName, transitionState);
    }
}

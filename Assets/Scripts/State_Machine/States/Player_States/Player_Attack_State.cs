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
        PlayAttackAnimation();

        attkCounter = 1.5f;
        attkTimer = 0.0f;

        player.input.OnPlayerAttack += Input_OnPlayerAttack;
        player.input.OnPlayerMove += Input_OnPlayerMove;
        player.input.OnPlayerJump += Input_OnPlayerJump;
        player.input.OnPlayerBlock += Input_OnPlayerBlock;
        player.character_Health_Component.OnDecrease_Health += Character_Health_Component_OnDecrease_Health;
        player.character_Health_Component.OnInsufficient_Health += Character_Health_Component_OnInsufficient_Health;
    }

    private void Character_Health_Component_OnInsufficient_Health()
    {
        base.state_Machine.SetState(base.transitions[nameof(Player_Dead_State)]);
    }

    private void Character_Health_Component_OnDecrease_Health()
    {
        base.state_Machine.SetState(base.transitions[nameof(Player_Hit_State)]);
    }

    private void Input_OnPlayerBlock(bool obj)
    {
        if (attkTimer >= attkCounter)
            base.state_Machine.SetState(base.transitions[nameof(Player_Block_State)]);
    }

    private void Input_OnPlayerJump(bool obj)
    {
        if (attkTimer >= attkCounter)
            base.state_Machine.SetState(base.transitions[nameof(Player_Jump_State)]);
    }

    private void Input_OnPlayerMove(Vector2 obj)
    {
        if (attkTimer >= attkCounter) 
        {
            player.movement = new Vector3(obj.x, 0f, obj.y).normalized;
            base.state_Machine.SetState(base.transitions[nameof(Player_Movement_State)]);
        }
    }

    private void Input_OnPlayerAttack(bool obj)
    {
        PlayAttackAnimation();
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

    public void PlayAttackAnimation()
    {
        player.anim.Play("Sword And Shield Slash");
    }

    public override void OnExit()
    {
        player.input.OnPlayerAttack -= Input_OnPlayerAttack;
        player.input.OnPlayerMove -= Input_OnPlayerMove;
        player.input.OnPlayerJump -= Input_OnPlayerJump;
        player.input.OnPlayerBlock -= Input_OnPlayerBlock;
        player.character_Health_Component.OnDecrease_Health -= Character_Health_Component_OnDecrease_Health;
        player.character_Health_Component.OnInsufficient_Health -= Character_Health_Component_OnInsufficient_Health;
    }

    public virtual void AddStateTransitions(string transitionName, State transitionState)
    {
        base.AddStateTransitions(transitionName, transitionState);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Hit_State : Player_Base_State
{
    private float animTime = 1.5f;
    private float animTimer = 0.0f;
    public Player_Hit_State(Player_State_Machine playerSM, Player_Component player) : base(nameof(Player_Hit_State), playerSM, player) { }

    public override void OnEnter()
    {
        base.OnEnter();
        player.character_Health_Component.OnInsufficient_Health += Character_Health_Component_OnInsufficient_Health;
        animTime = 1.5f;
        animTimer = 0.0f;
        PlayHitAnimation();
    }

    private void Character_Health_Component_OnInsufficient_Health()
    {
        base.state_Machine.SetState(base.transitions[nameof(Player_Dead_State)]);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (animTimer >= animTime)
            base.state_Machine.SetState(base.transitions[nameof(Player_Idle_State)]);
        else
            animTimer += Time.deltaTime;
    }


    public void PlayHitAnimation()
    {
        player.anim.Play("GetHit");
    }

    public override void OnExit()
    {
        base.OnExit();
        player.character_Health_Component.OnInsufficient_Health -= Character_Health_Component_OnInsufficient_Health;
    }

    public virtual void AddStateTransitions(string transitionName, State transitionState)
    {
        base.AddStateTransitions(transitionName, transitionState);
    }
}

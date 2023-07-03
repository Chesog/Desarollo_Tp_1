using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Dead_State : Player_Base_State
{
    public Player_Dead_State(Player_State_Machine playerSM, Player_Component player) : base(nameof(Player_Dead_State), playerSM, player) { }

    public override void OnEnter()
    {
        base.OnEnter();
        PlayDeadAnimation();
    }

    public void PlayDeadAnimation()
    {
        player.anim.Play("Death");
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public virtual void AddStateTransitions(string transitionName, State transitionState)
    {
        base.AddStateTransitions(transitionName, transitionState);
    }
}

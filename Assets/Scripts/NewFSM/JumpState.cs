using UnityEngine;

public class JumpState : BaseState
{
    protected JumpState(PlayerController player, Animator animator) : base(player, animator) { }

    public override void OnEnter()
    {
        _animator.CrossFade(JumpHash,crossFadeDuration);
    }

    public override void FixedUpdate()
    {
       //call for player jump logic and move logic
    }
}
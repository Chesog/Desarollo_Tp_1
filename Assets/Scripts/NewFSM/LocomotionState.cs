using UnityEngine;

public class LocomotionState : BaseState
{
    protected LocomotionState(PlayerController player, Animator animator) : base(player, animator) { }

    public override void OnEnter()
    {
        _animator.CrossFade(LocomotionHash,crossFadeDuration);
    }
    public override void FixedUpdate()
    {
         // call player controller move Logic
    }
}
using System;
using UnityEngine;

public class Player_Idle_State : Player_Base_State
{
    public Player_Idle_State(Player_State_Machine playerSM, Player_Component player) : base(nameof(Player_Idle_State), playerSM, player) { }

    public override void OnEnter()
    {
        base.OnEnter();
        PlayIdleAnimation();

        player.movement = Vector3.zero;
        player.input.OnPlayerMove += OnPlayerMove;
        player.input.OnPlayerJump += Input_OnPlayerJump;
    }



    private void OnPlayerMove(Vector2 newMovement)
    {
        player.movement = new Vector3(newMovement.x, 0f, newMovement.y).normalized;
        base.state_Machine.SetState(base.transitions[nameof(Player_Movement_State)]);
    }

    private void Input_OnPlayerJump(bool obj)
    {
        base.state_Machine.SetState(base.transitions[nameof(Player_Jump_State)]);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        float targetAngle = Mathf.Atan2(player.movement.x, player.movement.z) * Mathf.Rad2Deg + player.camera.eulerAngles.y;

        player.lastAngle = targetAngle;

        float angle = Mathf.SmoothDampAngle(player.GetComponent<Transform>().eulerAngles.y, targetAngle, ref player.turn_Smooth_Velocity, player.turnSmoothTime);

        player.GetComponent<Transform>().rotation = Quaternion.Euler(0f, angle, 0f);

        PlayIdleAnimation();
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }

    public void PlayIdleAnimation() 
    {
        player.anim.Play("Idle");
    }

    public override void OnExit()
    {
        base.OnExit();
        player.input.OnPlayerMove -= OnPlayerMove;
        player.input.OnPlayerJump -= Input_OnPlayerJump;
    }

    public override void AddStateTransitions(string transitionName, State transitionState)
    {
        base.AddStateTransitions(transitionName, transitionState);
        transitions.Add(transitionName, transitionState);
    }
}

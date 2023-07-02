using UnityEngine;

public class Player_Jump_State : Player_Base_State
{
    public Player_Jump_State(State_Machine state_Machine, Player_Component player) : base(nameof(Player_Jump_State), state_Machine, player) {}

    public override void OnEnter()
    {
        base.OnEnter();
        player.input.OnPlayerJump += Input_OnPlayerJump;
        player.input.OnPlayerMove += Input_OnPlayerMove;
    }

    private void Input_OnPlayerMove(Vector2 obj)
    {
        base.state_Machine.SetState(base.transitions[nameof(Player_Movement_State)]);
    }

    private void Input_OnPlayerJump(bool obj)
    {
        player.rigidbody.AddForce(Vector3.up * player.jumpForce, ForceMode.Impulse);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (isGrounded())
            base.state_Machine.SetState(base.transitions[nameof(Player_Idle_State)]);
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();

    }

    public override void OnExit()
    {
        base.OnExit();
        player.input.OnPlayerJump -= Input_OnPlayerJump;
        player.input.OnPlayerMove -= Input_OnPlayerMove;
    }

    public bool isGrounded()
    {
        return Physics.Raycast(player.feet_Pivot.position, Vector3.down, out var hit, player.maxDistance) && hit.distance <= player.minJumpDistance;
    }

    public override void AddStateTransitions(string transitionName, State transitionState)
    {
        base.AddStateTransitions(transitionName, transitionState);
        transitions.Add(transitionName, transitionState);
    }
}

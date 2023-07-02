using UnityEngine;

public class Player_Idle_State : Player_Base_State
{
    public Player_Idle_State(Player_State_Machine playerSM,Player_Component player) : base(nameof(Player_Idle_State), playerSM,player) {}

    public override void OnEnter()
    {
        base.OnEnter();
        player.movement = Vector3.zero;
        player.input.OnPlayerMove += OnPlayerMove;
    }

    private void OnPlayerMove(Vector2 newMovement) 
    {
        if (newMovement != Vector2.zero)
            base.state_Machine.SetState(base.transitions[nameof(Player_Movement_State)]);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }

    public override void AddStateTransitions(string transitionName, State transitionState)
    {
        base.AddStateTransitions(transitionName, transitionState);
        transitions.Add(transitionName,transitionState);
    }
}

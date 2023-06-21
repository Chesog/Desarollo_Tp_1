using UnityEngine;

public class Player_Idle : BaseState
{
    private Vector3 movement;

    public Player_Idle(Movement_State_Machine movementSM) : base(nameof(Player_Idle), movementSM) { }

    public override void OnEnter()
    {
        base.OnEnter();
        movement = Vector3.zero;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        //movement = input.GetValue
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
    }

    public override void AddStateTransitions(string transitionName, BaseState transitionState)
    {
        base.AddStateTransitions(transitionName, transitionState);
        transitions.Add(transitionName,transitionState);
    }
}

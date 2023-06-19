public enum CharacterState
{
    IDLE,
    WALKING,
    RUNNING,
    JUMPING,
    ATTACKING,
    TAKINGDAMAGE,
    DEAD
}

public class BaseState
{
    public string name;
    protected State_Machine state_Machine;

    public BaseState(string name,State_Machine state_Machine) 
    {
        this.name = name;
        this.state_Machine = state_Machine;
    }
    public virtual void OnEnter() { }
    public virtual void UpdateLogic() { }
    public virtual void UpdatePhysics() { }
    public virtual void OnExit() { }
}

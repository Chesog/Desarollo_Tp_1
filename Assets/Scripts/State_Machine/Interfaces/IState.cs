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

public interface IState
{
    public void onStateEnter();
    public void onStateExit();
}

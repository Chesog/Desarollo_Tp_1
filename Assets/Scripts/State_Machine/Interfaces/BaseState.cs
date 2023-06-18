using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public virtual void OnEnter() { }
    public virtual void UpdateLogic() { }
    public virtual void UpdatePhysics() { }
    public virtual void OnExit() { }
}

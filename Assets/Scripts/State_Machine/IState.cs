using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State 
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
    public void OnStateEnter();
    public void OnStateExit();
}

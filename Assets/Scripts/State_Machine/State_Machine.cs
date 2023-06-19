using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class State_Machine : MonoBehaviour
{
    [SerializeField] BaseState currentState;

    public UnityEvent onStateEnter;
    public UnityEvent onStateExit;

    private void OnEnable()
    {
        
    }

    private void Update()
    {
        
    }

    public void SetState(BaseState newState) 
    {
        if (newState == currentState)
            return;

        onStateExit?.Invoke();
        currentState.OnEnter();

        currentState = newState;

        onStateEnter?.Invoke();
        currentState.OnExit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class State_Machine : MonoBehaviour
{
    [SerializeField] IState currentState;

    public UnityEvent onStateEnter;
    public UnityEvent onStateExit;

    private void OnEnable()
    {
        
    }

    private void Update()
    {
        
    }

    public void SetState(IState newState) 
    {
        if (newState == currentState)
            return;

        onStateExit?.Invoke();
        currentState.onStateExit();

        currentState = newState;

        onStateEnter?.Invoke();
        currentState.onStateEnter();
    }
}

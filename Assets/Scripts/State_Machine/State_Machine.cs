using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class State_Machine : MonoBehaviour
{
    [SerializeField] BaseState currentState;

    public UnityEvent OnStateEnter;
    public UnityEvent OnStateExit;

    private void OnEnable()
    {
        currentState = GetInitialState();
        if (currentState != null)
            currentState.OnEnter();
    }

    private void Update()
    {
        if (currentState != null)
            currentState.UpdateLogic();
        ShowSate();
    }

    private void FixedUpdate()
    {
        if (currentState != null)
            currentState.UpdatePhysics();
        ShowSate();
    }

    protected virtual BaseState GetInitialState()
    {
        return null;
    }

    public void SetState(BaseState newState) 
    {
        if (newState == currentState)
            return;

        OnStateExit?.Invoke();
        currentState.OnEnter();

        currentState = newState;

        OnStateEnter?.Invoke();
        currentState.OnExit();
    }

    private void ShowSate() 
    {
        if (currentState != null)
            Debug.Log("Current State : " + currentState.name);
        else
            Debug.Log("No Current State");
    }
}

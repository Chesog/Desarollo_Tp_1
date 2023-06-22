using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class State_Machine : MonoBehaviour
{
    [SerializeField] State currentState;
    [HideInInspector]
    public UnityEvent OnStateEnter;
    [HideInInspector]
    public UnityEvent OnStateExit;

    protected virtual void OnEnable()
    {
        currentState = GetInitialState();
        if (currentState != null)
            currentState.OnEnter();
    }

    private void Update()
    {
        if (currentState != null)
            currentState.UpdateLogic();
    }

    private void FixedUpdate()
    {
        if (currentState != null)
            currentState.UpdatePhysics();
    }

    protected virtual State GetInitialState()
    {
        return null;
    }

    public void SetState(State newState) 
    {
        if (newState == null)
            Debug.LogError($"{name}:New State Is Null",this);

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

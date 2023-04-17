using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{
    // private CharacterController controller;

    Player_Movement movement;

    public event Action<Vector2> OnPlayerMove;
    public event Action<bool> OnPlayerJump;
    public event Action<bool> OnPlayerSprint;

    private void Start()
    {
       
    }

    public void OnMove(InputValue input)
    {
        if (OnPlayerMove != null)
        OnPlayerMove.Invoke(input.Get<Vector2>());
        else
            Debug.LogWarning($"On Move: event has no listeners");
    }

    public void OnJump(InputValue input)
    {
        if (OnPlayerJump != null)
            OnPlayerJump.Invoke(input.isPressed);
        else
            Debug.LogWarning($"On Jump: event has no listeners");
    }

    public void OnSprint(InputValue input)
    {
        if (OnPlayerSprint != null)
            OnPlayerSprint.Invoke(input.isPressed);
        else
            Debug.LogWarning($"On Sprint: event has no listeners");
    }
}

using System;
using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Class To Handle The Player Input
/// </summary>
public class Player_Input_Manager : MonoBehaviour
{
    [SerializeField] private PlayerInput input;

    /// <summary>
    /// Action Event For The Player Movement
    /// </summary>
    public event Action<Vector2> OnPlayerMove;

    /// <summary>
    /// Action Event For The Player Jump
    /// </summary>
    public event Action<bool> OnPlayerJump;

    /// <summary>
    /// Action Event For The Player Sprint
    /// </summary>
    public event Action<bool> OnPlayerSprint;

    /// <summary>
    /// Action Event For The Player Attack
    /// </summary>
    public event Action<bool> OnPlayerAttack;

    /// <summary>
    /// Action Event For The Player Block
    /// </summary>
    public event Action<bool> OnPlayerBlock;

    /// <summary>
    /// Action Event For The Player Take Damage
    /// </summary>
    public event Action OnPlayerTakeDamage;

    /// <summary>
    /// Action Event For The Player Dead
    /// </summary>
    public event Action OnPlayerDead;

    /// <summary>
    /// Action Event For The Player PickUp
    /// </summary>
    public event Action OnPlayerPickUp;

    /// <summary>
    /// Action Event For The Player Drop
    /// </summary>
    public event Action OnPlayerDrop;

    /// <summary>
    /// Action Event For The Player Pause
    /// </summary>
    public event Action OnPlayerPause;

    private void OnEnable()
    {
        input = GetComponent<PlayerInput>();
    }

    /// <summary>
    /// Triggers The Movement Event
    /// </summary>
    /// <param name="input"></param>
    public void OnMove(InputValue input)
    {
        OnPlayerMove.Invoke(input.Get<Vector2>());
    }


    /// <summary>
    /// Triggers The Jumping Event
    /// </summary>
    /// <param name="input"></param>
    public void OnJump(InputValue input)
    {
        //OnPlayerJump.Invoke(input.isPressed);
    }

    /// <summary>
    /// Triggers The Sprint Event
    /// </summary>
    /// <param name="input"></param>
    public void OnSprint(InputValue input)
    {
       // OnPlayerSprint.Invoke(input.isPressed);
    }

    /// <summary>
    /// Triggers The Block Event
    /// </summary>
    /// <param name="input"></param>
    public void OnR_Click(InputValue input)
    {
        OnPlayerBlock.Invoke(input.isPressed);
    }

    /// <summary>
    /// Triggers The Attack Event
    /// </summary>
    /// <param name="input"></param>
    public void OnL_Click(InputValue input)
    {
        OnPlayerAttack.Invoke(input.isPressed);
    }

    /// <summary>
    /// Triggers The PickUp Event
    /// </summary>
    public void OnPickUp()
    {
        OnPlayerPickUp?.Invoke();
    }

    /// <summary>
    /// Triggers The Drop Event
    /// </summary>
    public void OnDrop()
    {
        OnPlayerDrop?.Invoke();
    }

    /// <summary>
    /// Triggers The Pause Event
    /// </summary>
    public void OnPause()
    {
        OnPlayerPause?.Invoke();
    }
}

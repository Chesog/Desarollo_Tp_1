using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : MonoBehaviour
{
    // private CharacterController controller;

    Player_Movement movement;
    [SerializeField] private Player_Setings setings;

    public event Action<Vector2> OnPlayerMove;
    public event Action<bool> OnPlayerJump;
    public event Action<bool> OnPlayerSprint;
    public event Action<bool> OnPlayerAttack;
    public event Action<bool> OnPlayerBlock;

    private void Awake()
    {
       setings = new Player_Setings();
    }

    public Player_Setings GetPlayerSetings() 
    {
        return setings;
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

    public void OnR_Click(InputValue input)
    {
        if (OnPlayerBlock != null)
            OnPlayerBlock.Invoke(input.isPressed);
        else
            Debug.LogWarning($"On Sprint: event has no listeners");
    }

    public void OnL_Click(InputValue input)
    {
        if (OnPlayerAttack != null)
            OnPlayerAttack.Invoke(input.isPressed);
        else
            Debug.LogWarning($"On Sprint: event has no listeners");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            if (!setings.isBlocking)
            {
                TakeDamage(other.GetComponent<Bullet_Controller>().damage);
                Destroy(other.gameObject);
            }
            else
            {
                return;
            }
        }
    }

    

    public void TakeDamage(float damage) 
    {
        setings.health -= damage;
        if (setings.health <= 0)
        {
            Invoke(nameof(DestroyPlayer),0.5f);
        }
        Debug.Log("Player Health " + setings.health);
    }

    private void DestroyPlayer() 
    {
        Destroy(gameObject);
    }
}

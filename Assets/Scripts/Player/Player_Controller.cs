using System;
using System.Net.NetworkInformation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Player_Controller : MonoBehaviour
{
    //TODO: TP2 - Remove unused methods/variables
    // private CharacterController controller;

    Player_Movement movement;
    float health;
    [SerializeField] private Player_Setings setings;
    [SerializeField] private PlayerInput input;
    [SerializeField] private AudioClip swing;
    public Game_Manager _Manager;

    //TODO - Documentation - Add summary
    public event Action<Vector2> OnPlayerMove;
    public event Action<bool> OnPlayerJump;
    public event Action<bool> OnPlayerSprint;
    public event Action<bool> OnPlayerAttack;
    public event Action<bool> OnPlayerBlock;
    public event Action OnPlayerTakeDamage;
    public event Action OnPlayerDead;
    public event Action OnPlayerPickUp;
    public event Action OnPlayerDrop;
    public event Action OnPlayerPause;

    public static Player_Controller playerPos;
    public Transform playerHolder;


    //TODO: TP2 - Remove unused methods/variables
    //private void Awake()
    //{
    //    playerPos = this;
    //
    //    _Manager.SetMaxHealth(setings.health);
    //    health = setings.health;
    //}

    private void OnEnable()
    {
        playerPos = this;

        _Manager.SetMaxHealth(setings.health);
        health = setings.health;
    }

    public float GetHealth() 
    {
        return health;
    }

    public Player_Setings GetPlayerSetings()
    {
        return setings;
    }

    //TODO - Fix - Using Input related logic outside of an input responsible class (or input related class controls health)
    public void OnMove(InputValue input)
    {
        if (OnPlayerMove != null)
        {
            OnPlayerMove.Invoke(input.Get<Vector2>());
        }
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
            Debug.LogWarning($"OnR_Click: event has no listeners");
    }

    public void OnL_Click(InputValue input)
    {
        if (OnPlayerAttack != null)
            OnPlayerAttack.Invoke(input.isPressed);
        if (input.isPressed)
            SoundManager.Instance.PlaySound(swing);

        else
            Debug.LogWarning($"OnL_Click: event has no listeners");
    }

    public void OnPickUp(InputValue input) 
    {
        if (input.isPressed) 
        {
            //TODO: TP2 - SOLID
            Debug.Log("OnPlayerPickUp");
            OnPlayerPickUp.Invoke();
        }

    }

    public void OnDrop(InputValue input) 
    {
        if (input.isPressed) 
        {
            Debug.Log("OnPlayerDrop");
            OnPlayerDrop.Invoke();
        }
    }

    public void OnPause() 
    {
        OnPlayerPause.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        //TODO - Fix - Hardcoded value
        if (other.CompareTag("Bullet"))
        {
            if (!setings.isBlocking)
            {
                if (setings.health <= 0)
                    return;

                OnPlayerTakeDamage.Invoke();
                TakeDamage(other.GetComponent<Bullet_Controller>().damage);
                Destroy(other.gameObject);
            }
            else
            {
                return;
            }
        }
    }

    private void Update()
    {
        //TODO - Fix - Should be event based
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (health <= 0)
        {
            OnPlayerDead.Invoke();
            //TODO: TP2 - Remove unused methods/variables
            //Invoke(nameof(DestroyPlayer), 0.5f);
        }
        _Manager.SetHealth(health);
    }

    public void TakeDamage(float damage)
    {
        //TODO: TP2 - FSM
        if (health <= 0)
            return;

        health -= damage;
        Debug.Log("Player Health " + health);
    }

    private void DestroyPlayer()
    {
        Destroy(gameObject);
    }

}

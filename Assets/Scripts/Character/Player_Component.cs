using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Component : Character_Component
{
    public Player_Input_Manager input;
    [SerializeField] private Player_Data_Source player_Source;

    public Transform feet_Pivot;
    public Transform camera;
    public Transform weaponHolder;

    public float turn_Smooth_Velocity;
    public float turnSmoothTime;
    public float lastAngle;
    public float maxDistance;
    public float minJumpDistance;
    [Header("Character Coyote Time Setup")]
    public float coyoteTime;
    public float coyoteTimerCounter;

    private void Awake()
    {
        player_Source._player = this;
    }

    private void OnEnable()
    {
        character_Health_Component._maxHealth = 100f;
        initialSpeed = speed;
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }
}

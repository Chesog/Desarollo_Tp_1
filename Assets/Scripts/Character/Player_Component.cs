using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Component : Character_Component
{
    [SerializeField] private PlayerInput input;

    public float turn_Smooth_Velocity;
    public Transform feet_Pivot;
    public Transform camera;
    public float turnSmoothTime;
    [Header("Character Coyote Time Setup")]
    public float coyoteTime;
    public float coyoteTimerCounter;

    private void OnEnable()
    {
        character_Health_Component._maxHealth = 100f;
        speed = 5.0f;
        initialSpeed = speed;
        jumpForce = 10.0f;
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        jumpBufferTime = 2.0f;
    }
}

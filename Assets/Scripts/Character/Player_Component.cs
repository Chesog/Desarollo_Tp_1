using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Component : Character_Component
{
    public Player_Input_Manager input;

    public float turn_Smooth_Velocity;
    public Transform feet_Pivot;
    public Transform camera;
    public float turnSmoothTime;
    public float lastAngle;
    [Header("Character Coyote Time Setup")]
    public float coyoteTime;
    public float coyoteTimerCounter;

    private void OnEnable()
    {
        character_Health_Component._maxHealth = 100f;
        initialSpeed = speed;
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }
}

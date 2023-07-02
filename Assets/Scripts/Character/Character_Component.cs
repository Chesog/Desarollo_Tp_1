using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Component : MonoBehaviour
{
    [Header("Character SetUps")]
    public Health_Component character_Health_Component;
    public float speed;
    public float initialSpeed;
    public float jumpForce;
    public Vector3 movement;
    public Animator anim;
    public Rigidbody rigidbody;
    [Header("Character Jump Timers")]
    public float jumpBufferTime;
    public float jumpBufferTimeCounter;

    public void SetCharacter_Component(Health_Component _health, float speed, float initialSpeed, float jumpForce, Animator anim, Rigidbody rigidbody, float jumpBufferTime) 
    {
        character_Health_Component = _health;
        this.speed = speed;
        this.initialSpeed = initialSpeed;
        this.jumpForce = jumpForce;
        this.anim = anim;
        this.rigidbody = rigidbody;
        this.jumpBufferTime = jumpBufferTime;
    }
}

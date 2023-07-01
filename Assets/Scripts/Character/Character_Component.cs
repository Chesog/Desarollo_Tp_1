using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Component : MonoBehaviour
{
    [Header("Character SetUps")]
    [SerializeField] protected Health_Component character_Health_Component;
    [SerializeField] protected float speed;
    [SerializeField] protected float initialSpeed;
    [SerializeField] protected float jumpForce;
    [SerializeField] protected Vector3 movement;
    [SerializeField] protected Animator anim;
    [SerializeField] protected Rigidbody rigidbody;
    [Header("Character Jump Timers")]
    [SerializeField] protected float jumpBufferTime;

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

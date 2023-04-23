using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scripts/Player/Player Setings")]
public class Player_Setings : ScriptableObject
{
    [Header("Player SetUps")]
    public float health = 100f;
    [Range(0, 500)] public float speed = 20.0f;
    [Range(0, 500)] public float jumpForce = 20.0f;
    public float maxDistance = 10f;
    public float minJumpDistance = 0.5f;
    public bool isAttacking;
    public bool isBlocking;
    [Header("Player Jump Timers")]
    public float jumpBufferTime = 0.2f;
    public float turnSmoothTime = 0.1f;
    public float coyoteTime = 0.2f;
}

using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Scripts/Player/Player Setings")]
[Obsolete]public class Player_Setings : ScriptableObject
{
    [Header("Player SetUps")]
    public float health;
    [Range(0, 500)] public float speed;
    [Range(0, 500)] public float jumpForce;
    [SerializeField] private float turn_Smooth_Velocity;
    public float maxDistance;
    public float minJumpDistance;
    //TODO: TP2 - Remove unused methods/variables
    public bool isAttacking;
    public bool isBlocking;
    [Header("Player Jump Timers")]
    public float jumpBufferTime;
    public float turnSmoothTime;
    public float coyoteTime;
}

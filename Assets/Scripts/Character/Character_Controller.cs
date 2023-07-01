using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Container : MonoBehaviour
{
    [Header("Player SetUps")]
    private Health_Component health;
    [Range(0, 500)] public float speed;
    [Range(0, 500)] public float jumpForce;
    [SerializeField] private float turn_Smooth_Velocity;
    [SerializeField] private Animator anim;
    [Header("Player Jump Timers")]
    public float jumpBufferTime;
    public float turnSmoothTime;
    public float coyoteTime;

    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private Transform feet_Pivot;
    [SerializeField] private Transform playerCamera;

    [SerializeField] float initialSpeed;

    [Header("Coyote Time Setup")]
    [SerializeField] private float coyoteTimerCounter;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

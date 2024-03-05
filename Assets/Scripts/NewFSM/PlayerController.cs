using System;
using Cinemachine;
using KBCore.Refs;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : ValidatedMonoBehaviour
{
    [Header("References")] 
    [SerializeField, Self] private Animator _animator;
    [SerializeField, Self] private Rigidbody _rigidbody;
    [SerializeField, Anywhere] private GroundChecker groundChecker;
    [SerializeField, Anywhere] private CinemachineVirtualCamera _camera;
    [SerializeField, Anywhere] private InputReader _input;

    [Header("Settings")]
    [SerializeField] private float moveSpeed = 6.0f;
    [SerializeField] private float rotationSpeed = 15f;
    [SerializeField] private float smoothTime = 0.2f;
    
        
    Transform mainCam;
        
    private const float ZeroF = 0f;
    private float currentSpeed;
    private float velocity;
    private float dashVelocity = 1f;
    
    //Animator parameters
    private static readonly int Speed = Animator.StringToHash("Speed");

    private void Awake()
    {
        mainCam = Camera.main.transform;
    }

    private void Update()
    {
        HandleMovement();
        UpdateAnimator();
    }

    private void FixedUpdate()
    {
        HandleMovement();   
    }
    
    private void UpdateAnimator()
    {
        _animator.SetFloat(Speed, currentSpeed);
    }

    public void HandleMovement()
    {
        var movementDirection = new Vector3(_input.Direction.x, 0f, _input.Direction.y);
        // Rotate movement direction to match camera rotation
        var adjustedDirection = Quaternion.AngleAxis(mainCam.eulerAngles.y, Vector3.up) * movementDirection;
            
        if (adjustedDirection.magnitude > ZeroF) {
            HandleRotation(adjustedDirection);
            HandleHorizontalMovement(adjustedDirection);
            SmoothSpeed(adjustedDirection.magnitude);
        } else {
            SmoothSpeed(ZeroF);
                
            // Reset horizontal velocity for a snappy stop
            _rigidbody.velocity = new Vector3(ZeroF, _rigidbody.velocity.y, ZeroF);
        }
    }

    void HandleHorizontalMovement(Vector3 adjustedDirection)
    {
        // Move the player
        Vector3 velocity = adjustedDirection * (moveSpeed * dashVelocity * Time.fixedDeltaTime);
        _rigidbody.velocity = new Vector3(velocity.x, _rigidbody.velocity.y, velocity.z);
    }

    void HandleRotation(Vector3 adjustedDirection)
    {
        // Adjust rotation to match movement direction
        var targetRotation = Quaternion.LookRotation(adjustedDirection);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void SmoothSpeed(float value)
    {
        currentSpeed = Mathf.SmoothDamp(currentSpeed, value, ref velocity, smoothTime);
    }
}

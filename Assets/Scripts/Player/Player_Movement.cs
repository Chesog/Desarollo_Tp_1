using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Windows;

public class Player_Movement : MonoBehaviour
{
    private Player_Controller controller;

    [Header("SetUp")]
    private Player_Setings setings;
    [SerializeField] private Rigidbody rigidbody;
    [SerializeField] private Transform feet_Pivot;
    [SerializeField] private Transform playerCamera;
    [SerializeField] private float jumpBufferTimeCounter;
    [SerializeField] private float turnSmoothVelocity;
    private float lastAngle;
    private Coroutine _jumpCorutine;
    [Header("Movement")]
    [SerializeField] Vector3 _CurrentMovement;

    [SerializeField] float initialSpeed;
    [SerializeField] private bool isJumping;
    [SerializeField] private bool wasJumping;
    [SerializeField] private bool isSprinting;

    [Header("Coyote Time Setup")]
    [SerializeField] private float coyoteTimerCounter;

    public event Action<float> OnPlayerJump;
    public event Action<float> OnPlayerAttack;
    public event Action<float> OnPlayerBlock;

    private void Awake()
    {
        rigidbody ??= GetComponent<Rigidbody>();
        if (!rigidbody)
        {
            Debug.LogError(message: $"{name}: (logError){nameof(rigidbody)} is null");
            enabled = false;
        }

        feet_Pivot ??= GetComponent<Transform>();
        if (!feet_Pivot)
        {
            Debug.LogError(message: $"{name}: (logError){nameof(feet_Pivot)} is null");
        }

        controller ??= GetComponent<Player_Controller>();
        if (!controller)
        {
            Debug.LogError(message: $"{name}: (logError){nameof(controller)} is null");
        }

        setings = controller.GetPlayerSetings();

        isJumping = false;
        isSprinting = false;
        initialSpeed = setings.speed;
        Debug.Log("Player Speed : " + setings.speed);
    }

    private void Start()
    {
        controller.OnPlayerMove += Controller_OnPlayerMove;
        controller.OnPlayerJump += Controller_OnPlayerJump;
        controller.OnPlayerSprint += Controller_OnPlayerSprint;
        controller.OnPlayerAttack += Controller_OnPlayerAttack;
        controller.OnPlayerBlock += Controller_OnPlayerBlock;
    }

    public void FixedUpdate()
    {
        if (isGrounded())
        {
            coyoteTimerCounter = setings.coyoteTime;
            jumpBufferTimeCounter = setings.jumpBufferTime;
        }
        else
        {
            coyoteTimerCounter -= Time.deltaTime;
            jumpBufferTimeCounter -= Time.deltaTime;
        }

        if (_CurrentMovement.magnitude >= 1f)
        {
            if (isGrounded())
            {
                float targetAngle = Mathf.Atan2(_CurrentMovement.x, _CurrentMovement.z) * Mathf.Rad2Deg + playerCamera.eulerAngles.y;
                lastAngle = targetAngle;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, setings.turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);

                Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                //rigidbody.drag = 0f;
                rigidbody.velocity = moveDir.normalized * setings.speed + Vector3.up * rigidbody.velocity.y;
            }
            else
            {
                Vector3 moveDir = Quaternion.Euler(0f, lastAngle, 0f) * Vector3.forward;
                //rigidbody.drag = 0f;
                rigidbody.velocity = moveDir.normalized * setings.speed + Vector3.up * rigidbody.velocity.y;
            }

        }
        //else 
        //{
        //    rigidbody.drag = 10f;
        //}


        if (isSprinting)
        {
            setings.speed = initialSpeed * 2;
        }
        else
        {
            setings.speed = initialSpeed;
        }
        OnPlayerJump.Invoke(rigidbody.velocity.y);
    }

    private void Controller_OnPlayerMove(Vector2 obj)
    {
        if (!isGrounded())
            return;

        var movement = obj;
        _CurrentMovement = new Vector3(movement.x, 0f, movement.y).normalized;
    }

    private void Controller_OnPlayerJump(bool obj)
    {

        if (_jumpCorutine != null)
            StopCoroutine(_jumpCorutine);
        _jumpCorutine = StartCoroutine(JumpCorutine(setings.jumpBufferTime));

        StopCoroutine(JumpCorutine(setings.jumpBufferTime));
        if (obj && rigidbody.velocity.y > 0f)
        {
            rigidbody.velocity = _CurrentMovement * setings.speed + Vector3.up * rigidbody.velocity.y * 0.5f;
            coyoteTimerCounter = 0f;
        }
    }

    private void Controller_OnPlayerSprint(bool obj)
    {
        Debug.Log(obj);
        isSprinting = obj;
    }

    private void Controller_OnPlayerBlock(bool obj)
    {
        setings.isBlocking = obj;
    }

    private void Controller_OnPlayerAttack(bool obj)
    {
        setings.isAttacking = obj;
    }

    private IEnumerator JumpCorutine(float bufferTime)
    {
        if (!feet_Pivot)
        {
            yield break;
        }

        float timeElapsed = 0;

        while (timeElapsed <= bufferTime)
        {
            yield return new WaitForFixedUpdate();

            if (coyoteTimerCounter > 0f && jumpBufferTimeCounter > 0f && !isJumping)
            {
                rigidbody.velocity = new Vector3(rigidbody.velocity.x, 0f, rigidbody.velocity.z);
                rigidbody.AddForce(Vector3.up * setings.jumpForce, ForceMode.Impulse);
                if (timeElapsed > 0)
                {
                    Debug.Log(message: $"{name}: buffer jump for {timeElapsed} seconds");
                }
                yield break;

            }

            timeElapsed += Time.fixedDeltaTime;
        }
    }
    public bool isGrounded()
    {
        return Physics.Raycast(feet_Pivot.position, Vector3.down, out var hit, setings.maxDistance) && hit.distance <= setings.minJumpDistance;
    }
    private void OnDestroy()
    {
        controller.OnPlayerMove -= Controller_OnPlayerMove;
        controller.OnPlayerJump -= Controller_OnPlayerJump;
        controller.OnPlayerSprint -= Controller_OnPlayerSprint;
        controller.OnPlayerAttack -= Controller_OnPlayerAttack;
        controller.OnPlayerBlock -= Controller_OnPlayerBlock;
    }
}

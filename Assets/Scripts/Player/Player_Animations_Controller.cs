using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Animations_Controller : MonoBehaviour
{
    [Header("Anim Setup")]
    [SerializeField] private Animator anim;
    private Player_Controller controller;

    private void Awake()
    {
        controller ??= GetComponent<Player_Controller>();
        if (!controller)
        {
            Debug.LogError(message: $"{name}: (logError){nameof(controller)} is null");
        }

        anim ??= GetComponent<Animator>();
        if (!anim)
        {
            Debug.LogError(message: $"{name}: (logError){nameof(anim)} is null");
        }
    }

    private void Start()
    {
        controller.OnPlayerMove += Controller_OnPlayerMove;
        controller.OnPlayerJump += Controller_OnPlayerJump;
        controller.OnPlayerSprint += Controller_OnPlayerSprint;
    }
    private void Controller_OnPlayerMove(Vector2 obj)
    {
        Vector3 pos = new Vector3(obj.x,0f,obj.y);
        anim.SetFloat("VelocityX/Z", pos.magnitude - pos.y);
        anim.SetFloat("VelocityY", pos.y);
    }


    private void Controller_OnPlayerJump(bool obj)
    {
        anim.SetBool("IsJumping", obj);
    }

    private void Controller_OnPlayerSprint(bool obj)
    {
        anim.SetBool("IsRuning",obj);
    }

    private void OnDestroy()
    {
        controller.OnPlayerMove -= Controller_OnPlayerMove;
        controller.OnPlayerJump -= Controller_OnPlayerJump;
        controller.OnPlayerSprint -= Controller_OnPlayerSprint;
    }
}

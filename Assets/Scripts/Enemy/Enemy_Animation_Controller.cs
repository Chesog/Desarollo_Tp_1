using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Animation_Controller : MonoBehaviour
{
    [Header("Anim Setup")]
    [SerializeField] private Animator anim;
    [SerializeField] private Enemy_Controller controller;
    // Start is called before the first frame update
    void Start()
    {
        controller.OnEnemyMove += Controller_OnEnemyMove;
        controller.OnEnemyAttack += Controller_OnEnemyAttack;
        controller.OnEnemyHit += Controller_OnEnemyHit;
    }

    private void Controller_OnEnemyHit()
    {
        anim.Play("Get_Hit");
    }

    private void Controller_OnEnemyAttack()
    {
        anim.Play("Standing 1H Magic Attack 01");
    }

    private void Controller_OnEnemyMove(Vector2 obj)
    {
        Vector3 pos = new Vector3(obj.x, 0f, obj.y);
        anim.SetFloat("Velocity_X/Z",pos.magnitude - pos.y);
    }

    private void OnDestroy()
    {
        controller.OnEnemyMove -= Controller_OnEnemyMove;
        controller.OnEnemyAttack -= Controller_OnEnemyAttack;
        controller.OnEnemyHit -= Controller_OnEnemyHit;
    }
}

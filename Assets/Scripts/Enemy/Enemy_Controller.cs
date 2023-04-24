using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Controller : MonoBehaviour
{
    [SerializeField] private float lookRad = 20f;
    [SerializeField] private float stopDistance = 5f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float timeBetweenAttacks = 0.5f;
    [SerializeField] private bool alreadyAttacked;
    [SerializeField] private Transform target;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private Rigidbody rb;
    //[SerializeField] private Bullet bullet;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float health;

    public event Action<Vector2> OnEnemyMove;
    public event Action OnEnemyAttack;
    public event Action OnEnemyHit;

    private void Start()
    {
        target ??= GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (!target)
        {
            Debug.LogError(message: $"{name}: (logError){nameof(target)} is null");
            enabled = false;
        }

        rb ??= GetComponent<Rigidbody>();
        if (!rb)
        {
            Debug.LogError(message: $"{name}: (logError){nameof(rb)} is null");
            enabled = false;
        }
    }

    private void Update()
    {
        faceTarget();
        CheckHealth();
    }

    private void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, target.position);
        if (distance <= lookRad)
        {
            //transform.Translate(Vector3.forward * Time.deltaTime * speed);
            rb.velocity = gameObject.transform.forward * speed;
            if (distance <= stopDistance)
            {
                AttackPlayer();

                rb.velocity = new Vector3(0f, 0f, 0f);
            }
        }

        Vector2 pos = new Vector2(rb.velocity.x, rb.velocity.z);
        OnEnemyMove(pos);
    }

    private void CheckHealth()
    {
        if (health <= 0)
        {
            Invoke(nameof(DestroyEnemy), 0.5f);
        }
    }

    private void faceTarget()
    {
        transform.LookAt(target.position);
    }

    private void AttackPlayer()
    {
        if (!alreadyAttacked)
        {

            //Rigidbody projectile = Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            //projectile.AddForce(transform.forward * 32f, ForceMode.Impulse);
            //projectile.AddForce(transform.up * 8f, ForceMode.Impulse);

            OnEnemyAttack.Invoke();
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation);
            Bullet_Controller bulletScript = bullet.GetComponent<Bullet_Controller>();
            bulletScript.Fire();

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player_Weapon"))
        {
            TakeDamage(other.GetComponent<Weapon_Stats>().GetDamage());
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        OnEnemyHit.Invoke();
        Debug.Log(health);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRad);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, stopDistance);
    }
}

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
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float health;

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
        float distance = Vector3.Distance(transform.position,target.position);
        faceTarget();

        if (distance <= lookRad) 
        {
            //transform.Translate(Vector3.forward * Time.deltaTime * speed);
            rb.velocity = gameObject.transform.forward * speed;
            if (distance <= stopDistance)
            {
                AttackPlayer();

                rb.velocity = new Vector3(0f,0f,0f);
                //Attack the Target
            }
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
            Rigidbody projectile = Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            projectile.AddForce(transform.forward * 32f, ForceMode.Impulse);
            projectile.AddForce(transform.up * 8f, ForceMode.Impulse);
            
            alreadyAttacked = true;
            Invoke(nameof(ResetAttack),timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void TakeDamage(int damage) 
    {
        health -= damage;
        if (health <= 0)
        {
            Invoke(nameof(DestroyEnemy),0.5f);
        }
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

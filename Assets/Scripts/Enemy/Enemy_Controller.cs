using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Controller : MonoBehaviour
{
    [SerializeField] private float lookRad = 20f;
    [SerializeField] private float stopDistance = 5f;
    [SerializeField] private float speed = 5f;
    [SerializeField] private Transform target;
    [SerializeField] private Rigidbody rb;

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

                rb.velocity = new Vector3(0f,0f,0f);
                //Attack the Target
            }
        }
    }

    private void faceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
        transform.LookAt(target.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRad);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, stopDistance);
    }
}

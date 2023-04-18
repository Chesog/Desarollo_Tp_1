using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Controller : MonoBehaviour
{
    [SerializeField]private float lookRad = 10f;
    [SerializeField]private float stopDistance = 5f;
    [SerializeField] private Transform target;
    [SerializeField] NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (!agent)
        {
            Debug.LogError(message: $"{name}: (logError){nameof(agent)} is null");
            enabled = false;
        }
    }

    private void Update()
    {
        float distance  = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRad) 
        {

            transform.position = Vector3.MoveTowards(transform.position, target.position, 0.2f);
            Debug.Log("Stop Distance" + stopDistance);
            if (distance <= stopDistance)
            {
                Debug.Log("Distance" + distance);
                transform.position = transform.position;
                //Attack the Target
                faceTarget();
            }
        }
    }

    private void faceTarget() 
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime * 5f);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,lookRad);
    }
}

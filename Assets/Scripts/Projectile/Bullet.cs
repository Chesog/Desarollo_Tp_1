using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private bool isShoot;
    [SerializeField] private Transform target;
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        target ??= GameObject.FindGameObjectWithTag("Player").transform;
        if (!target)
        {
            Debug.LogError(message: $"{name}: (logError){nameof(target)} is null");
            enabled = false;
        }

        rb = GetComponent<Rigidbody>();
        if (!rb)
        {
            Debug.LogError(message: $"{name}: (logError){nameof(rb)} is null");
            enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isShoot)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, 0f);
            if (transform.position == target.position)
            {
                DestroyBullet();
            }
        }
    }

    public void AddBulletForce(Vector3 force, ForceMode mode)
    {
        rb.AddForce(force, mode);
    }

    public void SetIsShoot(bool value) 
    {
        isShoot = value;
    }

    public bool GetIsShoot() 
    {
        return isShoot;
    }

    public GameObject GetBulletPrefab() 
    {
        return bullet;
    }

    public void SetRbVelocity(Vector3 newVelocity)
    {
        rb.velocity = newVelocity;
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    public void SetParent(Transform parent)
    {
        this.parent = parent;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == target.tag)
        {
            Invoke(nameof(DestroyBullet), 0.5f);
        }
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}

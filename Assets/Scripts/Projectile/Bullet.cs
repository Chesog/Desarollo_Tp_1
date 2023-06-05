using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO - Fix - Wtf is this class?...
public class Bullet : MonoBehaviour
{
    //TODO: TP2 - Remove unused methods/variables
    [SerializeField] private float speed;
    [SerializeField] private bool isShoot;
    [SerializeField] private Transform target;
    [SerializeField] private Transform parent;
    //TODO: TP2 - SOLID
    [SerializeField] private GameObject bullet;
    [SerializeField] private Rigidbody rb;

    //TODO: TP2 - Syntax - Consistency in access modifiers (private/protected/public/etc)
    // Start is called before the first frame update
    void Start()
    {
        //TODO - Fix - Hardcoded value
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

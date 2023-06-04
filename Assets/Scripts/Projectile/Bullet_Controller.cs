using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Controller : MonoBehaviour
{
    public float speed = 10f; // speed of the bullet
    public float lifetime = 5f; // lifetime of the bullet in seconds
    public float damage = 5f;

    private float timer; // timer to keep track of how long the bullet has been alive

    void Start()
    {
        timer = 0f; // initialize the timer
    }

    void Update()
    {
        //TODO - Fix - Code is in Spanish or is trash code
        // move the bullet forward at a constant speed
        transform.position += transform.forward * speed * Time.deltaTime;

        // increment the timer
        timer += Time.deltaTime;

        //destroy the bullet if it has been alive for longer than its lifetime
        if (timer >= lifetime)
        {
            Destroy(gameObject);
        }
    }

    public void Fire()
    {
        // Move the bullet forward using the code from the previous answer
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}

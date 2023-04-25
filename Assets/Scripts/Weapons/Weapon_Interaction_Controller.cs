using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapon_Interaction_Controller : MonoBehaviour
{
    [SerializeField] private Weapon_Stats weapon;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private BoxCollider coll;
    [SerializeField] private Transform player;
    [SerializeField] private Transform weapon_Container;

    [SerializeField] private float pickUp_Range;
    [SerializeField] private float dropForwardForce;
    [SerializeField] private float dropUpwardForce;

    [SerializeField] private bool equiped;
    [SerializeField] private static bool slotFull;


    private void Start()
    {
        if (!equiped)
        {
            weapon.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
        }
        else
        {
            weapon.enabled = true;
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
        }
    }

    private void Update()
    {
        Vector3 distance = player.position - transform.position;
        if (!equiped && distance.magnitude <= pickUp_Range && !slotFull && Input.GetKeyDown(KeyCode.E))
        {
            PickUp_Weapon();
        }

        if (equiped && Input.GetKeyDown(KeyCode.Q))
        {
            Drop_Weapon();
        }
    }

    public void OnPickUp(InputValue input)
    {
        Debug.Log("PickUp");
        Vector3 distance = player.position - transform.position;
        if (!equiped && distance.magnitude <= pickUp_Range && !slotFull)
        {
            PickUp_Weapon();
        }
    }

    public void OnDrop(InputValue input)
    {
        Debug.Log("Drop");
        if (equiped)
        {
            Drop_Weapon();
        }
    }

    private void PickUp_Weapon()
    {
        equiped = true;
        slotFull = true;

        transform.SetParent(weapon_Container);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        //transform.localScale = Vector3.one;

        rb.isKinematic = true;
        coll.isTrigger = true;
        weapon.enabled = true;
    }

    private void Drop_Weapon()
    {
        equiped = false;
        slotFull = false;

        transform.SetParent(null);

        rb.isKinematic = false;
        coll.isTrigger = false;

        rb.velocity = player.GetComponent<Rigidbody>().velocity;
        rb.AddForce(player.forward * dropForwardForce, ForceMode.Impulse);
        rb.AddForce(player.up * dropUpwardForce, ForceMode.Impulse);

        float rand = Random.Range(-1f, 1f);
        rb.AddTorque(new Vector3(rand, rand, rand) * 10f);
        weapon.enabled = false;
    }

    private void OnDrawGizmos()
    {
        if (!equiped)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, pickUp_Range);
        }
    }
}

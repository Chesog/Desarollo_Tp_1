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
    //TODO: TP2 - Syntax - Consistency in naming convention
    [SerializeField] private static bool slotFull;


    private void Start()
    {

        if (player == null)
        {
            player = Player_Controller.playerPos.transform;
        }
        if (!player)
        {
            Debug.LogError(message: $"{name}: (logError){nameof(player)} is null");
            enabled = false;
        }

        //weapon_Container ??= Player_Controller.playerPos.playerHolder;
        if (weapon_Container == null)
        {
            weapon_Container = Player_Controller.playerPos.playerHolder;

        }
        if (!player)
        {
            Debug.LogError(message: $"{name}: (logError){nameof(weapon_Container)} is null");
            enabled = false;
        }

        if (!equiped)
        {
            weapon.enabled = false;
            //rb.isKinematic = false;
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

    private void Awake()
    {
        Player_Controller.playerPos.OnPlayerPickUp += PlayerPos_OnPlayerPickUp;
        Player_Controller.playerPos.OnPlayerDrop += PlayerPos_OnPlayerDrop;
    }

    private void PlayerPos_OnPlayerDrop()
    {
        if (equiped)
        {
            Drop_Weapon();
        }
    }

    private void PlayerPos_OnPlayerPickUp()
    {
        Vector3 distance = player.position - transform.position;
        if (!equiped && distance.magnitude <= pickUp_Range && !slotFull)
        {
            PickUp_Weapon();
        }
    }

    private void Update()
    {
        if (equiped)
        {
            UpdateEquipedPos();
        }
    }

    private void UpdateEquipedPos() 
    {
        transform.localPosition = Vector3.zero;
    }

    private void PickUp_Weapon()
    {
        equiped = true;
        slotFull = true;

        rb.isKinematic = true;
        coll.isTrigger = true;
        weapon.enabled = true;


        transform.SetParent(weapon_Container);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
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

    private void OnDestroy()
    {
        Player_Controller.playerPos.OnPlayerPickUp -= PlayerPos_OnPlayerPickUp;
        Player_Controller.playerPos.OnPlayerDrop -= PlayerPos_OnPlayerDrop;
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

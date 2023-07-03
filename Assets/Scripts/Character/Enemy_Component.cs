using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Component : Character_Component
{
    [SerializeField] private float lookRad = 20f;
    [SerializeField] private float stopDistance = 5f;
    [SerializeField] private float timeBetweenAttacks = 0.5f;
    [SerializeField] private float destroyTime;
    [SerializeField] private float destroyTimer;
    [SerializeField] private bool alreadyAttacked;
    [SerializeField] private bool deathLoop;
    [SerializeField] private Transform target;
    [SerializeField] private Transform bulletSpawn;

    [SerializeField] private Player_Data_Source player_Source;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Enemy_Animation_Controller enemyAnimController;

    private void OnEnable()
    {
        character_Health_Component._maxHealth = 100f;
        initialSpeed = speed;
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }
}

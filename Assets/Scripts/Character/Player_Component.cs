using UnityEngine;

/// <summary>
/// Class That Contains The Player Variables
/// </summary>
public class Player_Component : Character_Component
{
    public Player_Input_Manager input;
    public Player_Data_Source player_Source;

    public Weapon_Stats current_Weapon;
    public float current_Weapon_Rad;
    public float current_Weapon_MaxDistance;

    public Transform feet_Pivot;
    public Transform camera;
    public Transform weaponHolder;

    public float turn_Smooth_Velocity;
    public float turnSmoothTime;
    public float lastAngle;
    public float maxDistance;
    public float minJumpDistance;
    [Header("Character Coyote Time Setup")]
    public float coyoteTime;
    public float coyoteTimerCounter;

    public bool isPlayer_Attacking;

    private void Start()
    {
        current_Weapon = null;
        character_Health_Component._maxHealth = 100.0f;
        character_Health_Component._health = character_Health_Component._maxHealth;

        feet_Pivot ??= GetComponent<Transform>();
    }

    private void Awake()
    {
        character_Health_Component._maxHealth = 100.0f;
        character_Health_Component._health = character_Health_Component._maxHealth;
        player_Source._player = this;


        if (current_Weapon == null)
        {
            current_Weapon = weaponHolder.GetComponentInChildren<Weapon_Stats>();
        }
        if (!current_Weapon)
        {
            Debug.LogError(message: $"{name}: (logError){nameof(current_Weapon)} is null");
            enabled = false;
        }

        feet_Pivot ??= GetComponent<Transform>();
        if (!feet_Pivot)
        {
            Debug.LogError(message: $"{name}: (logError){nameof(feet_Pivot)} is null");
        }
    }

    public void SetCurrentWeapon(Weapon_Stats weapon)
    {
        current_Weapon = weapon;
    }

    private void OnEnable()
    {
        character_Health_Component._maxHealth = 100.0f;
        character_Health_Component._health = character_Health_Component._maxHealth;
        initialSpeed = speed;
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    private void OnDrawGizmos()
    {
        if (isPlayer_Attacking)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position + transform.forward + new Vector3(0f, current_Weapon_MaxDistance, current_Weapon_MaxDistance), current_Weapon_Rad);
        }
    }
}

using UnityEngine;

/// <summary>
/// Class That Contains The Player Variables
/// </summary>
public class Player_Component : Character_Component
{
    public Player_Input_Manager input;
    public Player_Data_Source player_Source;

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

    private void Start()
    {
        character_Health_Component._maxHealth = 100.0f;
        character_Health_Component._health = character_Health_Component._maxHealth;
        player_Source._player = this;
        feet_Pivot ??= GetComponent<Transform>();
    }
    private void Awake()
    {
        character_Health_Component._maxHealth = 100.0f;
        character_Health_Component._health = character_Health_Component._maxHealth;

        if (player_Source._player == null)
        {
            player_Source._player = this;
        }
        if (!player_Source._player)
        {
            Debug.LogError(message: $"{name}: (logError){nameof(player_Source._player)} is null");
            enabled = false;
        }
        feet_Pivot ??= GetComponent<Transform>();
        if (!feet_Pivot)
        {
            Debug.LogError(message: $"{name}: (logError){nameof(feet_Pivot)} is null");
        }
    }

    private void OnEnable()
    {
        character_Health_Component._maxHealth = 100.0f;
        character_Health_Component._health = character_Health_Component._maxHealth;
        initialSpeed = speed;
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }
}

using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Class For The Management Of Canvas And Some Audio
/// </summary>
public class Game_Manager : MonoBehaviour
{
    public Player_Data_Source player;

    private const string main_Menu_Name = "Main_Menu";
    private const string boss_Tag = "Boss";
    private const string game_Scene_Name = "wfc_Test";
    [SerializeField] private Slider healthBar;
    [SerializeField] private AudioClip GameMusic;
    [SerializeField] private GameObject BossEnemy;
    [SerializeField] private float BossEnemy_Health;
    [SerializeField] private GameObject game_Canvas;
    [SerializeField] private GameObject Pause_Canvas;
    [SerializeField] private GameObject Lose_Canvas;
    [SerializeField] private GameObject Win_Canvas;

    private void Start()
    {
        player._player.GetPlayerInputReader().Pause += Input_OnPlayerPause;
    }

    private void OnEnable()
    {
        game_Canvas.active = true;
        Pause_Canvas.active = false;
        Lose_Canvas.active = false;
        Win_Canvas.active = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        SoundManager.Instance.StopMusic();
        SoundManager.Instance.PlayMusic(GameMusic);
        BossEnemy = GameObject.FindGameObjectWithTag(boss_Tag);

        SetMaxHealth();
    }

    public void Update()
    {
        if (BossEnemy ==  null)
            BossEnemy = GameObject.FindGameObjectWithTag(boss_Tag);
        if (BossEnemy != null)
        {
            if (BossEnemy.active) 
            {
                BossEnemy_Health = BossEnemy.GetComponent<Enemy_Component>().character_Health_Component._health;
                if (BossEnemy_Health <= 0)
                {
                    game_Canvas.active = false;
                    Pause_Canvas.active = false;
                    Lose_Canvas.active = false;
                    Win_Canvas.active = true;
                }
            }
        }

        if (player._player.GetPlayerHealthComponent()._health <= 0)
        {
            game_Canvas.active = false;
            Pause_Canvas.active = false;
            Lose_Canvas.active = true;
            Win_Canvas.active = false;
        }

        if (Pause_Canvas.active)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        UpdateHealth();
    }

    /// <summary>
    /// Function To Change The Current Scene To The Menu Scene
    /// </summary>
    public void BackToMenu()
    {
        Time.timeScale = 1;
        SoundManager.Instance.StopMusic();
        SceneManager.LoadScene(main_Menu_Name);
    }

    /// <summary>
    /// Function To Reload The Current Scene
    /// </summary>
    public void ReloadScene()
    {
        Time.timeScale = 1;
        SoundManager.Instance.StopMusic();
        SceneManager.LoadScene(game_Scene_Name);
    }

    /// <summary>
    /// Function To Set The Value For The On Screen Health Bar
    /// </summary>
    public void UpdateHealth()
    {
        healthBar.value = player._player.GetPlayerHealthComponent()._health;
    }

    /// <summary>
    /// Set The Max Value Of The On Screen Health Bar
    /// </summary>
    public void SetMaxHealth()
    {
        healthBar.maxValue = player._player.GetPlayerHealthComponent()._maxHealth;
        healthBar.value = player._player.GetPlayerHealthComponent()._maxHealth;
    }

    /// <summary>
    /// Function To Handle The Canbas On Pause State
    /// </summary>
    private void Input_OnPlayerPause()
    {
        if (Pause_Canvas.active == true)
        {
            if (player._player.GetPlayerHealthComponent()._health > 0)
            {
                Pause_Canvas.active = false;
                game_Canvas.active = true;
                Lose_Canvas.active = false;
                Win_Canvas.active = false;
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            Pause_Canvas.active = true;
            game_Canvas.active = false;
            Lose_Canvas.active = false;
            Win_Canvas.active = false;
        }
    }

  

    private void OnDisable()
    {
       player._player.GetPlayerInputReader().Pause -= Input_OnPlayerPause;
    }
}

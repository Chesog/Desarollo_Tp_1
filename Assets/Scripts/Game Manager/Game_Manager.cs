using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    //TODO: TP2 - SOLID
    [SerializeField] Slider healthBar;
    [SerializeField] AudioClip GameMusic;
    [SerializeField] GameObject BossEnemy;
    [SerializeField] float BossEnemy_Health;
    [SerializeField] float Player_Health;
    [SerializeField] GameObject game_Canvas;
    [SerializeField] GameObject Pause_Canvas;
    [SerializeField] GameObject Lose_Canvas;
    [SerializeField] GameObject Win_Canvas;
    [SerializeField] Player_Component player;

    //TODO - Documentation - Add summary
    //TODO: TP2 - FSM

    private void OnEnable()
    {
        //TODO - Fix - Repeated code
        game_Canvas.active = true;
        Pause_Canvas.active = false;
        Lose_Canvas.active = false;
        Win_Canvas.active = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        SoundManager.Instance.StopMusic();
        SoundManager.Instance.PlayMusic(GameMusic);
        BossEnemy = GameObject.FindGameObjectWithTag("Boss");

        player.input.OnPlayerPause += Input_OnPlayerPause;
    }

    /// <summary>
    /// Fuction To Handle The Canbas On Pause State
    /// </summary>
    private void Input_OnPlayerPause()
    {
        if (Pause_Canvas.active == true)
        {
            if (player.character_Health_Component._health > 0)
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

    public void Update()
    {
        if (BossEnemy != null) 
        {
            BossEnemy_Health = BossEnemy.GetComponent<Enemy_Controller>().GetHealth();
            if (BossEnemy_Health <= 0)
            {
                game_Canvas.active = false;
                Pause_Canvas.active = false;
                Lose_Canvas.active = false;
                Win_Canvas.active = true;
            }
        }


        Player_Health = Player_Controller.playerPos.GetComponent<Player_Controller>().GetHealth();

        if (player.character_Health_Component._health <= 0)
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
    }

    /// <summary>
    /// Function To Change The Current Scene To The Menu Scene
    /// </summary>
    public void BackToMenu() 
    {
        //TODO - Fix - Hardcoded values
        Time.timeScale = 1;
        SoundManager.Instance.StopMusic();
        SceneManager.LoadScene("Main_Menu");
    }

    /// <summary>
    /// Function To Reload The Current Scene
    /// </summary>
    public void ReloadScene() 
    {
        Time.timeScale = 1;
        SoundManager.Instance.StopMusic();
        SceneManager.LoadScene("wfc_Test");
    }

    /// <summary>
    /// Function To Set The Value For The On Screen Health Bar
    /// </summary>
    public void SetHealth() 
    {
        healthBar.value = player.character_Health_Component._health;
    }

    /// <summary>
    /// Set The Max Value Of The On Screen Health Bar
    /// </summary>
    public void SetMaxHealth()
    {
        healthBar.maxValue = player.character_Health_Component._maxHealth;
        healthBar.value = player.character_Health_Component._maxHealth;
    }

    private void OnDisable()
    {
        player.input.OnPlayerPause -= Input_OnPlayerPause;
    }
}

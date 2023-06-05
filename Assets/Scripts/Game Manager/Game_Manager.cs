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

    //TODO - Documentation - Add summary
    private void Start()
    {
        //TODO: TP2 - FSM
        game_Canvas.active = true;
        Pause_Canvas.active = false;
        Lose_Canvas.active = false;
        Win_Canvas.active = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    
        SoundManager.Instance.StopMusic();
        SoundManager.Instance.PlayMusic(GameMusic);
        //TODO: TP2 - SOLID
        BossEnemy = GameObject.FindGameObjectWithTag("Boss");
    
        Player_Controller.playerPos.OnPlayerPause += PlayerPos_OnPlayerPause;
    }

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

        Player_Controller.playerPos.OnPlayerPause += PlayerPos_OnPlayerPause;
    }

    private void PlayerPos_OnPlayerPause()
    {
        //TODO: TP2 - FSM
        if (Pause_Canvas.active == true)
        {
            if (Player_Health > 0)
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

        if (Player_Health <= 0)
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

    public void BackToMenu() 
    {
        //TODO - Fix - Hardcoded values
        Time.timeScale = 1;
        SoundManager.Instance.StopMusic();
        SceneManager.LoadScene("Main_Menu");
    }

    public void ReloadScene() 
    {
        Time.timeScale = 1;
        SoundManager.Instance.StopMusic();
        SceneManager.LoadScene("wfc_Test");
    }

    //TODO - Fix - Should be native Setter/Getter
    public void SetHealth(float health) 
    {
        healthBar.value = health;
    }

    public void SetMaxHealth(float health)
    {
        healthBar.maxValue = health;
        healthBar.value = health;
    }

    private void OnDisable()
    {
        Player_Controller.playerPos.OnPlayerPause -= PlayerPos_OnPlayerPause;
    }

    private void OnDestroy()
    {
        Player_Controller.playerPos.OnPlayerPause -= PlayerPos_OnPlayerPause;
    }
}

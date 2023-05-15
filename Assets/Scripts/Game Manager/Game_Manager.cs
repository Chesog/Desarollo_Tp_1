using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    [SerializeField] Slider healthBar;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void SetHealth(float health) 
    {
        healthBar.value = health;
        Debug.LogWarning("Player healt " + health);
    }

    public void SetMaxHealth(float health)
    {
        healthBar.maxValue = health;
        healthBar.value = health;
    }
}

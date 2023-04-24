using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    [SerializeField] Slider healthBar;

    public void SetHealth(float health) 
    {
        healthBar.value = health;
    }

    public void SetMaxHealth(float health)
    {
        healthBar.maxValue = health;
        healthBar.value = health;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Component : MonoBehaviour
{
    public float _health {get; set;}
    public float _maxHealth {get; set;}

    private void OnEnable()
    {
        _health = _maxHealth;
    }

    public void DecreaseHealth(float harm_Value) 
    {
        _health -= harm_Value;
    }

    public void IncreaseHealth(float heal_Value) 
    {
        _health += heal_Value;
    }

    private void OnDisable()
    {
        _health = 0;
        _maxHealth = 0;
    }
}

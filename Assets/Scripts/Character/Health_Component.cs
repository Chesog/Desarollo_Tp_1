using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Component : MonoBehaviour
{
    [SerializeField] public float _health { get; set; }
    [SerializeField] public float _maxHealth { get; set; }

    public event Action OnDecrease_Health;
    public event Action OnInsufficient_Health;

    private void OnEnable()
    {
        _health = _maxHealth;
    }

    public void DecreaseHealth(float harm_Value)
    {
        _health -= harm_Value;
        OnDecrease_Health?.Invoke();
        CheckHealth();
    }

    public void IncreaseHealth(float heal_Value)
    {
        _health += heal_Value;

        if (_health > _maxHealth)
            _health = _maxHealth;

        CheckHealth();
    }

    public void CheckHealth()
    {
        if (_health <= 0)
            OnInsufficient_Health?.Invoke();
    }

    private void OnDisable()
    {
        _health = 0;
        _maxHealth = 0;
    }
}

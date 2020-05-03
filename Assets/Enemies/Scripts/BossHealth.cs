using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour, IHealth, ILevelListener
{


    public delegate void TakeDamageHandler();
    public event TakeDamageHandler OnTakeDamage;

    [SerializeField] private int _maxHealth;
    private int _health;

    public float HealthPercentage { get => (float)_health / _maxHealth; }
    
    public void OnLevelStart()
    {
        _health = _maxHealth;
    }

    public void OnLevelEnd()
    {
    }

    public void DealDamage()
    {
        _health -= 1;
        if (OnTakeDamage != null)
        {
            OnTakeDamage();
        }
    }

}

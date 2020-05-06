using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{

    [SerializeField] private GameObject _deathEffectPrefab;

    public delegate void PlayerDeathHandler();

    public event PlayerDeathHandler OnPlayerDeath;
    
    public void DealDamage()
    {
        if (OnPlayerDeath != null)
        {
            OnPlayerDeath();
        }
        Instantiate(_deathEffectPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}

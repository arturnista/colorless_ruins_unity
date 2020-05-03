using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IHealth
{

    public delegate void PlayerDeathHandler();

    public event PlayerDeathHandler OnPlayerDeath;
    
    public void DealDamage()
    {
        if (OnPlayerDeath != null)
        {
            OnPlayerDeath();
        }
        Destroy(gameObject);
    }

}

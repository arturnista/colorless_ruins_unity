using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayerOnTrigger : MonoBehaviour
{

    [SerializeField] private bool _destroyOnTrigger = false;
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        IHealth health = collider.GetComponent<IHealth>();
        if (health != null)
        {
            health.DealDamage();
        }
        if (_destroyOnTrigger) Destroy(gameObject);
    }

}

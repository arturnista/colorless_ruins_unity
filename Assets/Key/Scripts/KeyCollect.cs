using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyCollect : MonoBehaviour
{
    
    [SerializeField] private Door _door;
    [SerializeField] private GameObject _soundPrefab;

    void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerKey key = collider.GetComponent<PlayerKey>();
        if (key)
        {
            _door.Open();
            if (_soundPrefab != null) Instantiate(_soundPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    void OnDrawGizmos()
    {
        if (_door != null)
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(transform.position, _door.transform.position);
        }
    }

}

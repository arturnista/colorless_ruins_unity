using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollect : MonoBehaviour
{

    [SerializeField] private GameObject _soundPrefab;

    void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerFruits fruits = collider.GetComponent<PlayerFruits>();
        if (fruits)
        {
            fruits.Collect();
            Instantiate(_soundPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}

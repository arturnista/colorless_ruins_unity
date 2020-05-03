using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObjectOnTrigger : MonoBehaviour
{

    [SerializeField] private GameObject _prefab;
    [SerializeField] private Vector3 _position;
    [SerializeField] private Space _relateTo = Space.World;

    private Vector3 SpawnPosition { get => _relateTo == Space.World ? _position : transform.position + _position; }

    void OnTriggerEnter2D(Collider2D collider)
    {
        Instantiate(_prefab, SpawnPosition, Quaternion.identity, transform.parent);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(SpawnPosition, Vector3.one);
    }
}

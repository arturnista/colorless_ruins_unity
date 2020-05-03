using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMultipleAttack : MonoBehaviour
{
    
    [SerializeField] private GameObject _orbPrefab;
    [SerializeField] private int _amount = 5;
    [SerializeField] private AudioClip _attackSound;

    private AudioSource _audioSource;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Fire(int _amountMultiplier = 1)
    {
        int amount = _amount * _amountMultiplier;
        float angleUnit = 360f / amount;
        for (int i = 0; i < amount; i++)
        {
            FireOrb(angleUnit * i * Mathf.Deg2Rad);
        }

        if (_attackSound != null)
        {
            _audioSource.PlayOneShot(_attackSound);
        }
    }

    void FireOrb(float angle)
    {
        Vector3 spawnPosition = transform.position;
        OrbMovement orbMovement = Instantiate(_orbPrefab, spawnPosition, Quaternion.identity, transform.parent).GetComponent<OrbMovement>();
        orbMovement.MoveAtDirection(
            new Vector2(
                Mathf.Cos(angle),
                Mathf.Sin(angle)
            )
        );
    }

    void OnDrawGizmosSelected()
    {  
        float angleUnit = 360f / _amount;
        for (int i = 0; i < _amount; i++)
        {
            float angle = angleUnit * i * Mathf.Deg2Rad;
            Vector2 dir = new Vector2(
                Mathf.Cos(angle),
                Mathf.Sin(angle)
            ) * 2f;
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, dir);
        }        
    }

}

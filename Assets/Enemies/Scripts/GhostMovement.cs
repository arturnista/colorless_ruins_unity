using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour, ILevelListener, IPausable
{
    [SerializeField] private float _moveSpeed;

    private float _currentMoveSpeed;
    private float _beforeCurrentMoveSpeed;

    private PlayerHealth _health;
    private Rigidbody2D _rigidbody;

    private Vector3 _spawnPosition;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spawnPosition = transform.position;
    }

    public void OnLevelStart()
    {
        _health = GameObject.FindObjectOfType<PlayerHealth>();
        _currentMoveSpeed = _moveSpeed;
    }
    
    public void OnLevelEnd()
    {
        transform.position = _spawnPosition;
        
        _health = null;
        _rigidbody.velocity = Vector2.zero;
        StopAllCoroutines();
    }

    void Update()
    {
        if (_health == null) return;

        Vector3 direction = (_health.transform.position - transform.position).normalized;
        _rigidbody.velocity = direction * _currentMoveSpeed;
    }

    public void OnPause()
    {
        _beforeCurrentMoveSpeed = _currentMoveSpeed;
        _currentMoveSpeed = 0f;
    }

    public void OnResume()
    {
        _currentMoveSpeed = _beforeCurrentMoveSpeed;
    }
}

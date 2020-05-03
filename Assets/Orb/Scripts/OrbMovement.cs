using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbMovement : MonoBehaviour, IPausable
{
    
    [SerializeField] private float _moveSpeed;

    private Rigidbody2D _rigidbody;
    private Vector3 _velocity;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void MoveAtDirection(Vector2 direction)
    {
        _velocity = direction * _moveSpeed;
        _rigidbody.velocity = _velocity;
    }

    public void OnPause()
    {
        _rigidbody.velocity = Vector3.zero;
    }

    public void OnResume()
    {
        _rigidbody.velocity = _velocity;
    }

}

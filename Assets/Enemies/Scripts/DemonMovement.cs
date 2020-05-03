using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonMovement : MonoBehaviour, ILevelListener, IPausable
{
    
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _timeMoving;
    [SerializeField] private float _timeWaiting;

    private float _currentMoveSpeed;
    private float _beforeCurrentMoveSpeed;

    private PlayerHealth _health;
    private Rigidbody2D _rigidbody;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void OnLevelStart()
    {
        _health = GameObject.FindObjectOfType<PlayerHealth>();
        StartCoroutine(MoveSpeedCoroutine());
    }
    
    public void OnLevelEnd()
    {
        _health = null;
        StopAllCoroutines();
    }

    void Update()
    {
        if (_health == null) return;

        Vector3 direction = (_health.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle -= 90f;

        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        _rigidbody.velocity = transform.up * _currentMoveSpeed;
    }

    IEnumerator MoveSpeedCoroutine()
    {
        while (true)
        {
            _currentMoveSpeed = 0f;
            yield return new WaitForSecondsPausable(_timeWaiting);

            _currentMoveSpeed = _moveSpeed;
            yield return new WaitForSecondsPausable(_timeMoving);
        }
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

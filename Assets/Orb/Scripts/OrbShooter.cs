using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbShooter : MonoBehaviour, ILevelListener, IPausable
{
    
    [SerializeField] private float _startDelay = 0f;
    [SerializeField] private float _fireDelay;
    [SerializeField] private GameObject _orbPrefab;
    [Space]
    [SerializeField] private Transform _indicatorMask;

    private AudioSource _audioSource;

    private float _fireTime;
    private bool _isPaused;

    void Awake()
    {
        _fireTime = _fireDelay;
        _audioSource = GetComponent<AudioSource>();
    }

    public virtual void OnLevelStart()
    {
        StartCoroutine(FireCoroutine());
    }

    public void OnLevelEnd()
    {
        StopAllCoroutines();
    }

    public void OnPause()
    {
        _isPaused = true;
    }

    public void OnResume()
    {
        _isPaused = false;
    }

    IEnumerator FireCoroutine()
    {
        if (_startDelay > 0) yield return new WaitForSeconds(_startDelay);

        while (true)
        {
            if (!_isPaused)
            {
                _fireTime += Time.deltaTime;

                if (_indicatorMask != null)
                {
                    float perc = Mathf.Clamp01(_fireTime / _fireDelay);
                    _indicatorMask.localScale = new Vector3(perc, 1f, 1f);
                }
                
                if (_fireTime > _fireDelay)
                {
                    Fire();
                    _fireTime = 0f;
                }
            }
            yield return null;
        }
    }

    void Fire()
    {
        if (_audioSource != null)
        {
            _audioSource.Play();
        }
        
        Vector2 fireDirection = GetAttackDirection();
        Vector3 spawnPosition = transform.position + ((Vector3)fireDirection * .5f);
        OrbMovement orbMovement = Instantiate(_orbPrefab, spawnPosition, Quaternion.identity, transform.parent).GetComponent<OrbMovement>();
        orbMovement.MoveAtDirection(fireDirection);
    }

    protected virtual Vector2 GetAttackDirection()
    {
        return transform.right;
    }

}

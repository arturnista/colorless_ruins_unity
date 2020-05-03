using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnightSymbol : MonoBehaviour
{
    
    [SerializeField] private Sprite _activatedSprite;
    [SerializeField] private GameObject _gemPrefab;
    [SerializeField] private ParticleSystem _activatedSystem;

    private SpriteRenderer _spriteRenderer;

    void Awake()
    {
        _activatedSystem.Stop();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void Activate()
    {
        _spriteRenderer.sprite = _activatedSprite;
        Instantiate(_gemPrefab, transform.position, Quaternion.identity, transform.parent);
        _activatedSystem.Play();
    }

}

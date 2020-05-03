using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    
    [SerializeField] private Sprite _closeSprite;
    [SerializeField] private Sprite _openSprite;

    private SpriteRenderer _spriteRenderer;
    private BoxCollider2D _boxCollider;

    private bool _isOpen;

    void Awake()
    {
        _boxCollider = GetComponent<BoxCollider2D>();

        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        _spriteRenderer.sprite = _closeSprite;
        _isOpen = !_boxCollider.enabled;
        if (_isOpen) Open();
    }

    public void Open()
    {
        _boxCollider.enabled = false;
        _spriteRenderer.sprite = _openSprite;
        _isOpen = true;
    }

}

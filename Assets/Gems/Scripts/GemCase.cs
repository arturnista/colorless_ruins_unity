using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCase : MonoBehaviour, IHealth
{
    
    [SerializeField] private List<Sprite> _sprites;
    private int _spriteIndex = 0;

    private SpriteRenderer _spriteRenderer;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void DealDamage()
    {
        _spriteIndex += 1;
        if (_sprites.Count > _spriteIndex)
        {
            _spriteRenderer.sprite = _sprites[_spriteIndex];
        }
        else
        {
            Destroy(gameObject);
        }
    }

}

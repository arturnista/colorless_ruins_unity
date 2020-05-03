using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIFruitsDisplay : MonoBehaviour, IPlayerListener, IPausable
{
    
    [SerializeField] private TextMeshProUGUI _valueText;

    private int _lastCount;

    private PlayerFruits _playerFruits;
    private Canvas _canvas;

    void Awake()
    {
        _canvas = GetComponent<Canvas>();
        _canvas.enabled = false;
    }

    public void OnPause()
    {
        _canvas.enabled = true;
    }

    public void OnResume()
    {
        _canvas.enabled = false;
    }

    public void OnPlayerCreate(GameObject player)
    {
        _playerFruits = player.GetComponent<PlayerFruits>();
        _lastCount = _playerFruits.FruitCount;
        
        UpdateCount();
    }

    void Update()
    {
        if (_lastCount != _playerFruits.FruitCount)
        {
            _lastCount = _playerFruits.FruitCount;
            UpdateCount();
        }
    }

    void UpdateCount()
    {
        _valueText.text = _playerFruits.FruitCount.ToString();
        StartCoroutine(CollectCoroutine());
    }

    IEnumerator CollectCoroutine()
    {
        _canvas.enabled = true;

        yield return new WaitForSecondsPausable(5f);

        _canvas.enabled = false;
    }
}

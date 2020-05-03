using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIBoss : MonoBehaviour, ILevelListener
{

    [SerializeField] private Image _healthValue;

    private Canvas _canvas;

    private BossHealth _bossHealth;

    void Awake()
    {
        _canvas = GetComponent<Canvas>();
        _canvas.enabled = false;
    }

    public void OnLevelStart()
    {
        _canvas.enabled = true;
        _bossHealth = GameObject.FindObjectOfType<BossHealth>();
        if (_bossHealth != null)
        {
            _bossHealth.OnTakeDamage += HandleTakeDamage;
            UpdateHealth();
        }
    }

    public void OnLevelEnd()
    {
        _canvas.enabled = false;
        _bossHealth.OnTakeDamage -= HandleTakeDamage;
    }

    void HandleTakeDamage()
    {
        UpdateHealth();
    }

    void UpdateHealth()
    {
        _healthValue.fillAmount = _bossHealth.HealthPercentage;
    }

}

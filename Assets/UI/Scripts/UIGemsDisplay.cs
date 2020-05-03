using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGemsDisplay : MonoBehaviour, IPlayerListener, IPausable
{
    
    [SerializeField] private Image _redGemImage;
    [SerializeField] private Image _blueGemImage;
    [SerializeField] private Image _greenGemImage;
    [SerializeField] private Image _yellowGemImage;
    [Space]
    [SerializeField] private Sprite _redGemSprite;
    [SerializeField] private Sprite _blueGemSprite;
    [SerializeField] private Sprite _greenGemSprite;
    [SerializeField] private Sprite _yellowGemSprite;

    private Sprite _redGemEmptySprite;
    private Sprite _blueGemEmptySprite;
    private Sprite _greenGemEmptySprite;
    private Sprite _yellowGemEmptySprite;

    private bool _lastRed;
    private bool _lastBlue;
    private bool _lastGreen;
    private bool _lastYellow;

    private PlayerGems _playerGems;
    private Canvas _canvas;

    void Awake()
    {
        _canvas = GetComponent<Canvas>();
        _canvas.enabled = false;

        _redGemEmptySprite = _redGemImage.sprite;
        _blueGemEmptySprite = _blueGemImage.sprite;
        _greenGemEmptySprite = _greenGemImage.sprite;
        _yellowGemEmptySprite = _yellowGemImage.sprite;
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
        _playerGems = player.GetComponent<PlayerGems>();

        _lastRed = _playerGems.Red;
        SetGem(_playerGems.Red, _redGemImage, _redGemEmptySprite, _redGemSprite);

        _lastBlue = _playerGems.Blue;
        SetGem(_playerGems.Blue, _blueGemImage, _blueGemEmptySprite, _blueGemSprite);

        _lastGreen = _playerGems.Green;
        SetGem(_playerGems.Green, _greenGemImage, _greenGemEmptySprite, _greenGemSprite);

        _lastYellow = _playerGems.Yellow;
        SetGem(_playerGems.Yellow, _yellowGemImage, _yellowGemEmptySprite, _yellowGemSprite);
        
        StartCoroutine(CollectCoroutine());
    }

    void Update()
    {
        if (_playerGems == null) return;

        if (_lastRed != _playerGems.Red)
        {
            _lastRed = _playerGems.Red;
            StartCoroutine(CollectCoroutine());
            SetGem(_playerGems.Red, _redGemImage, _redGemEmptySprite, _redGemSprite);
        }

        if (_lastBlue != _playerGems.Blue)
        {
            _lastBlue = _playerGems.Blue;
            StartCoroutine(CollectCoroutine());
            SetGem(_playerGems.Blue, _blueGemImage, _blueGemEmptySprite, _blueGemSprite);
        }

        if (_lastGreen != _playerGems.Green)
        {
            _lastGreen = _playerGems.Green;
            StartCoroutine(CollectCoroutine());
            SetGem(_playerGems.Green, _greenGemImage, _greenGemEmptySprite, _greenGemSprite);
        }

        if (_lastYellow != _playerGems.Yellow)
        {
            _lastYellow = _playerGems.Yellow;
            StartCoroutine(CollectCoroutine());
            SetGem(_playerGems.Yellow, _yellowGemImage, _yellowGemEmptySprite, _yellowGemSprite);
        }
    }

    void SetGem(bool value, Image image, Sprite emptySprite, Sprite sprite)
    {
        if (value) image.sprite = sprite;
        else image.sprite = emptySprite;
    }

    IEnumerator CollectCoroutine()
    {
        _canvas.enabled = true;

        yield return new WaitForSecondsPausable(5f);

        _canvas.enabled = false;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIMessage : MonoBehaviour
{
    
    public static UIMessage Main;

    [SerializeField] private TextMeshProUGUI _textMesh;
    [SerializeField] private TextMeshProUGUI _pressAnyKeyTextMesh;
    [Space]
    [SerializeField] private List<AudioClip> _charAudios;

    private AudioSource _audioSource;

    private string _message;
    private int _pos;
    private Canvas _canvas;

    private bool _isShowing;
    private bool _canBeClosed;
    
    private const float _defaultShowSpeed = .08f;
    private const float _fastShowSpeed = .02f;
    private float _showSpeed;

    void Awake()
    {
        Main = this;
        _audioSource = GetComponent<AudioSource>();

        _canvas = GetComponent<Canvas>();
        _canvas.enabled = false;
        _isShowing = false;
        _canBeClosed = false;
    }

    public void Show(string message)
    {
        _message = message;
        StartCoroutine(ShowMessageCoroutine());
    }

    void Update()
    {
        if (!_isShowing) return;
        if (Input.anyKeyDown)
        {
            if (_canBeClosed)
            {
                Close();
            }
            else if (_showSpeed == _defaultShowSpeed)
            {
                _showSpeed = _fastShowSpeed;
            }
            else
            {
                StopAllCoroutines();
                ReadyToClose();
            }
        }
    }

    IEnumerator ShowMessageCoroutine()
    {
        PauseController.Main.Pause(true);

        _pressAnyKeyTextMesh.gameObject.SetActive(false);
        _isShowing = true;
        _canBeClosed = false;
        _canvas.enabled = true;
        _pos = 0;
        _showSpeed = _defaultShowSpeed;

        while (_pos < _message.Length)
        {
            _pos += 1;
            _textMesh.text = _message.Substring(0, _pos);
            _audioSource.PlayOneShot(_charAudios[Random.Range(0, _charAudios.Count)]);
            yield return new WaitForSeconds(_showSpeed);
        }
        
        yield return new WaitForSeconds(1f);
        ReadyToClose();
    }

    void ReadyToClose()
    {
        _textMesh.text = _message;
        _canBeClosed = true;
        _pressAnyKeyTextMesh.gameObject.SetActive(true);
    }

    void Close()
    {
        _canvas.enabled = false;
        _isShowing = false;
        PauseController.Main.Resume(true);
    }

}

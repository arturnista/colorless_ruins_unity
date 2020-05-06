using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class UISlider : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _valueText;
    [Space]
    [SerializeField] private string _postString;

    private AudioSource _audioSource;

    public Slider.SliderEvent OnValueChanged { get => _slider.onValueChanged; }
    public float Value
    {
        get => _slider.value;
        set
        {
            _slider.value = value;
            HandleSliderChange(value);
        }
    }

    void OnEnable()
    {
        _audioSource = GetComponent<AudioSource>();
        _slider.onValueChanged.AddListener(HandleSliderChange);
        HandleSliderChange(_slider.value);
    }

    void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(HandleSliderChange);
    }

    void HandleSliderChange(float value)
    {
        _valueText.text = value + " " + _postString;
        if (_audioSource != null) _audioSource.Play();
    }

}

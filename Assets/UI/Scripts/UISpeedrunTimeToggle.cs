using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UISpeedrunTimeToggle : MonoBehaviour
{
    
    private Toggle _toggle;
    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _toggle = GetComponent<Toggle>();
        _toggle.isOn = Configuration.Main.SpeedrunTimer;

        _toggle.onValueChanged.AddListener((value) =>
        {
            _audioSource.Play();
            Configuration.Main.SpeedrunTimer = value;
        });
    }

}

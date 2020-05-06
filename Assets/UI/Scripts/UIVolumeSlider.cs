using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UIVolumeSlider : MonoBehaviour
{
    
    private UISlider _uiSlider;

    void Awake()
    {
        _uiSlider = GetComponent<UISlider>();
        
        _uiSlider.Value = Configuration.Main.Volume;
        _uiSlider.OnValueChanged.AddListener((value) => Configuration.Main.Volume = _uiSlider.Value);
    }

}

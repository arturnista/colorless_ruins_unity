using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITimerDisplay : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI _valueText;

    void Start()
    {
        if (!Configuration.Main.SpeedrunTimer)
        {
            gameObject.SetActive(false);
        }
    }
    
    void Update()
    {
        _valueText.text = Format.Time(Time.time - GameController.SaveData.StartTime);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILink : MonoBehaviour
{
    
    [SerializeField] private string _link;

    private Button _button;

    void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() => Application.OpenURL(_link));
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMenuButton : MonoBehaviour
{
    
    private Button _button;
    private AudioSource _audioSource;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() => 
        {
            _audioSource.Play();
            SceneManager.LoadScene("Menu");
        });
    }

}

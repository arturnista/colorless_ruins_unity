using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIStartGameButton : MonoBehaviour
{
    
    [SerializeField] private Image _displayImage;

    private Button _button;
    private AudioSource _audioSource;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() => StartCoroutine(FadeoutCoroutine()));
    }

    IEnumerator FadeoutCoroutine()
    {
        _audioSource.Play();
        
        float alpha = 0f;
        
        Color black = Color.black;
        black.a = alpha;
        _displayImage.color = black;

        _displayImage.gameObject.SetActive(true);

        while (alpha < 1f)
        {
            alpha += Time.deltaTime;
            black.a = alpha;
            _displayImage.color = black;
            yield return null;
        }

        SceneManager.LoadScene("StartCutscene");
    }

}

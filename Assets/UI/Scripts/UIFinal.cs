using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIFinal : MonoBehaviour
{
    
    [SerializeField] private AudioClip _fruitAudio;
    [SerializeField] private TextMeshProUGUI _fruitsText;
    [Space]
    [SerializeField] private AudioClip _collectAudio;
    [SerializeField] private Animator _redAnimator;
    [SerializeField] private Animator _blueAnimator;
    [SerializeField] private Animator _greenAnimator;
    [SerializeField] private Animator _yellowAnimator;
    [Space]
    [SerializeField] private TextMeshProUGUI _timeText;

    private const int _maxFruitCount = 9;

    private AudioSource _audioSource;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        
        _timeText.text = "";
        _fruitsText.text = string.Format("0 / {0}", _maxFruitCount);

        if (GameController.SaveData != null)
        {
            StartCoroutine(UIStartCoroutine());
        }
    }

    IEnumerator UIStartCoroutine()
    {
        yield return new WaitForSeconds(1f);
        
        for (int i = 1; i <= GameController.SaveData.FruitCount; i++)
        {
            _fruitsText.text = string.Format("{0} / {1}", i, _maxFruitCount);
            _audioSource.PlayOneShot(_fruitAudio);
            yield return new WaitForSeconds(.3f);
        }

        if (GameController.SaveData.RedGem)
        {
            yield return new WaitForSeconds(1f);
            _redAnimator.SetBool("IsCollected", true);
            _audioSource.PlayOneShot(_collectAudio);
        }

        if (GameController.SaveData.BlueGem)
        {
            yield return new WaitForSeconds(1f);
            _blueAnimator.SetBool("IsCollected", true);
            _audioSource.PlayOneShot(_collectAudio);
        }

        if (GameController.SaveData.GreenGem)
        {
            yield return new WaitForSeconds(1f);
            _greenAnimator.SetBool("IsCollected", true);
            _audioSource.PlayOneShot(_collectAudio);
        }

        if (GameController.SaveData.YellowGem)
        {
            yield return new WaitForSeconds(1f);
            _yellowAnimator.SetBool("IsCollected", true);
            _audioSource.PlayOneShot(_collectAudio);
        }

        if (Configuration.Main.SpeedrunTimer)
        {
            yield return new WaitForSeconds(1f);
            _audioSource.PlayOneShot(_fruitAudio);
            _timeText.text = Format.Time(Time.time - GameController.SaveData.StartTime);
        }

    }

}

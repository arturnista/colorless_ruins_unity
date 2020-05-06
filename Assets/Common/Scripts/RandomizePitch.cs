using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizePitch : MonoBehaviour
{
    
    [SerializeField] [Range(0f, 1f)] private float _minValue;
    [SerializeField] [Range(0f, 1f)] private float _maxValue;

    private AudioSource _audioSource;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.pitch = Random.Range(_minValue, _maxValue);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalPortal : MonoBehaviour
{

    private ParticleSystem _effect;

    void Awake()
    {
        _effect = GetComponentInChildren<ParticleSystem>();
    }

    public void Activate()
    {
        _effect.Play();
    }
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject.FindObjectOfType<GameController>().Save();
        SceneManager.LoadScene("Final");
    }
}

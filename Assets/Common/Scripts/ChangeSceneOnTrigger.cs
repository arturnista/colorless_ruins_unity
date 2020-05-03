using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnTrigger : MonoBehaviour
{

    [SerializeField] private string _sceneName;
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        SceneManager.LoadScene(_sceneName);
    }
}

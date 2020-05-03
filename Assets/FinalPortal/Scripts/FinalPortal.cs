using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalPortal : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject.FindObjectOfType<GameController>().Save();
        SceneManager.LoadScene("Final");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPause : MonoBehaviour, IPausable
{

    private Canvas _canvas;

    void Awake()
    {
        _canvas = GetComponent<Canvas>();
    }

    public void OnPause()
    {
        _canvas.enabled = true;
    }

    public void OnResume()
    {
        _canvas.enabled = false;
    }
}

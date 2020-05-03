using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour, ILevelListener, IPausable
{
    
    [SerializeField] private float _rotateSpeed = 120f;
    private bool _isPaused;

    void Update()
    {
        if (_isPaused) return;
        transform.Rotate(0f, 0f, _rotateSpeed * Time.deltaTime);
    }

    public void OnLevelStart()
    {
        Continue();
    }

    public void OnLevelEnd()
    {
        Stop();
    }

    public void OnPause()
    {
        Stop();
    }

    public void OnResume()
    {
        Continue();
    }

    void Stop()
    {
        _isPaused = true;
    }

    void Continue()
    {
        _isPaused = false;
    }

}

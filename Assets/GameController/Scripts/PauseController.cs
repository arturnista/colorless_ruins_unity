using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{

    public static PauseController Main;
    public static bool IsPaused {
        get { return Main ? Main._isPaused : false; }
    }

    private bool _isPaused;
    private bool _wasForced;

    void Awake()
    {
        Main = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
    }

    void Toggle()
    {
        if (_isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Pause(bool force = false)
    {
        _wasForced = force;
        _isPaused = true;
        var pausables = GetComponentsInChildren<IPausable>();
        foreach (var item in pausables)
        {
            item.OnPause();
        }
    }

    public void Resume(bool force = false)
    {
        if (_wasForced && !force) return;
        _isPaused = false;
        var pausables = GetComponentsInChildren<IPausable>();
        foreach (var item in pausables)
        {
            item.OnResume();
        }
    }

}

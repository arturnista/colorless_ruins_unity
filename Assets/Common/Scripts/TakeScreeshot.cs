using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeScreeshot : MonoBehaviour
{
#if UNITY_EDITOR
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        StartCoroutine(ScreenshotCoroutine());
    }

    IEnumerator ScreenshotCoroutine()
    {
        while (true)
        {
            ScreenCapture.CaptureScreenshot(string.Format("Build/Screenshots/SS_{0}.png", DateTime.Now.ToString("yyyyMMddHHmmss")));
            yield return new WaitForSeconds(5f);
        }
    }
#endif
}

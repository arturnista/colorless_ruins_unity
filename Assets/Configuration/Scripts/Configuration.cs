using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Configuration
{

    private const string RESOURCE_MIXER = "Mixer/SoundMixer";

    private const string TIMER_PREFS_NAME = "SpeedrunTimer";
    private const string VOLUME_PREFS_NAME = "Volume";

    private static Configuration s_Configuration;
    public static Configuration Main { get => s_Configuration; }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void OnBeforeSceneLoad()
    {

        s_Configuration = new Configuration();

    }
    
    private bool m_SpeedrunTimer;
    public bool SpeedrunTimer
    {
        get => m_SpeedrunTimer;
        set
        {
            PlayerPrefs.SetInt(TIMER_PREFS_NAME, value ? 1 : 0);
            m_SpeedrunTimer = value;
        }
    }
    
    private AudioMixer _audioMixer;
    private float m_Volume;
    public float Volume
    {
        get => m_Volume;
        set
        {
            PlayerPrefs.SetFloat(VOLUME_PREFS_NAME, value);
            m_Volume = value;
            SetVolume();
        }
    }

    private Configuration()
    {
        _audioMixer = Resources.Load(RESOURCE_MIXER) as AudioMixer;

        m_SpeedrunTimer = PlayerPrefs.GetInt(TIMER_PREFS_NAME, 0) == 1;
        m_Volume = PlayerPrefs.GetFloat(VOLUME_PREFS_NAME, 50f);
        SetVolume();
    }

    void SetVolume()
    {
        float normalized = (m_Volume / 100f);
        normalized = Mathf.Clamp(normalized, 0.0001f, 1f);
        _audioMixer.SetFloat("Volume", Mathf.Log10(normalized) * 20f);
        Debug.Log(normalized);
    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Configuration
{

    private static Configuration s_Configuration;
    public static Configuration Main { get => s_Configuration; }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    static void OnBeforeSceneLoad()
    {

        s_Configuration = new Configuration();

    }
    
    private bool m_SpeedrunTimer;
    public bool SpeedrunTimer { get => m_SpeedrunTimer; set => m_SpeedrunTimer = value; }

    private Configuration()
    {
        m_SpeedrunTimer = false;
    }

}
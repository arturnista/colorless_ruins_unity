using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGems : MonoBehaviour
{
    private bool m_Red;
    public bool Red { get => m_Red; set => m_Red = value; }
    
    private bool m_Blue;
    public bool Blue { get => m_Blue; set => m_Blue = value; }

    private bool m_Green;
    public bool Green { get => m_Green; set => m_Green = value; }

    private bool m_Yellow;
    public bool Yellow { get => m_Yellow; set => m_Yellow = value; }

    void Awake()
    {
        m_Red = false;
        m_Blue = false;
        m_Green = false;
        m_Yellow = false;
    }

    public void CollectRed()
    {
        m_Red = true;
    }

    public void CollectBlue()
    {
        m_Blue = true;
    }

    public void CollectGreen()
    {
        m_Green = true;
    }

    public void CollectYellow()
    {
        m_Yellow = true;
    }

}

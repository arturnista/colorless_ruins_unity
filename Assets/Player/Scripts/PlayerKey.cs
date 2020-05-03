using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKey : MonoBehaviour
{
    
    private bool _hasKey;

    void Awake()
    {
        _hasKey = false;
    }

    public void Collect()
    {
        _hasKey = true;
    }

    public bool UseKey()
    {
        if (_hasKey)
        {
            _hasKey = false;
            return true;
        }
        else
        {
            return false;
        }
    }

}

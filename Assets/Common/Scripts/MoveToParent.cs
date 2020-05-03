using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToParent : MonoBehaviour
{
    
    [SerializeField] private string _parentName = "World/Dynamic";

    void Awake()
    {
        transform.parent = GameObject.Find(_parentName).transform;
    }

}

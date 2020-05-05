using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData
{
    
    public float StartTime;

    public bool HasFreeMovement;

    public int FruitCount;

    public bool RedGem;
    public bool BlueGem;
    public bool GreenGem;
    public bool YellowGem;


    public SaveData()
    {
        HasFreeMovement = false;
        FruitCount = 0;

        RedGem = false;
        BlueGem = false;
        GreenGem = false;
        YellowGem = false;

        StartTime = Time.time;
    }

    public SaveData(SaveData copy)
    {
        HasFreeMovement = copy.HasFreeMovement;
        FruitCount = copy.FruitCount;

        RedGem = true;
        BlueGem = true;
        GreenGem = true;
        YellowGem = true;
    }
    
}

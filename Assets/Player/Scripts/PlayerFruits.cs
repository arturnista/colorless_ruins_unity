using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFruits : MonoBehaviour
{

    private static bool s_FruitTextWasShow = false;

    private int _fruitCount;
    public int FruitCount { get => _fruitCount; set => _fruitCount = value; }

    void Awake()
    {
        _fruitCount = 0;
    }

    public void Collect()
    {
        if (_fruitCount == 0 && !s_FruitTextWasShow)
        {
            s_FruitTextWasShow = true;
            UIMessage.Main.Show("You eat the fruit. A delicious sensation pervades your whole body.\nYou almost forgot the fear you feel from this dark place.\n\nIt has no useful purpose for your objetive, but can be a nice treat.");
        }
        _fruitCount += 1;
    }

}

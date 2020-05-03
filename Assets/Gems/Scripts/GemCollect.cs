using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemCollect : MonoBehaviour
{
    
    public enum GemColor
    {
        Red,
        Blue,
        Green,
        Yellow
    }

    [SerializeField] private GemColor _color;
    [SerializeField] private GameObject _soundPrefab;

    void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerGems gems = collider.GetComponent<PlayerGems>();
        if (gems)
        {
            switch (_color)
            {
                case GemColor.Red:
                    gems.CollectRed();
                    break;
                case GemColor.Blue:
                    gems.CollectBlue();
                    break;
                case GemColor.Green:
                    gems.CollectGreen();
                    break;
                case GemColor.Yellow:
                    gems.CollectYellow();
                    break;
            }
            Instantiate(_soundPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}

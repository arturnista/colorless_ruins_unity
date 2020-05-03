using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            var listeners = GetComponentsInParent<IPlayerDetectorListener>();
            foreach (var listener in listeners)
            {
                listener.OnPlayerDetect(collider.gameObject);
            }
        }
    }

}

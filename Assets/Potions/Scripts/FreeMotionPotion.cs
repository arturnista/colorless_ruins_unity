using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeMotionPotion : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D collider)
    {
        PlayerMovement movement = collider.GetComponent<PlayerMovement>();
        if (movement)
        {
            movement.HasFreeMovement = true;
            UIMessage.Main.Show("You drink the blue potion.\nAs it goes down your throat, you feel a very strong taste.\n\nBut now, somehow, you can move almost freely.");
            Destroy(gameObject);
        }
    }
}

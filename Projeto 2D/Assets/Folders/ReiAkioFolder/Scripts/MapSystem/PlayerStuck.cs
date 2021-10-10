using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStuck : MonoBehaviour
{
    private float checkTime = 0.001f;
    public CindyPlayerMovement mapIcon;
    private bool collisionAux;


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "wall")
        {
            mapIcon.moveSpeed = 0;
            collisionAux = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "wall")
        {
            mapIcon.moveSpeed = 5;
            collisionAux = false;
        }
    }
    
}

using System;
using System.Collections;
using System.Collections.Generic;
using Folders.HaFolder;
using UnityEngine;

public class TrapScript : ElementalObjects
{

    private void Awake()
    {
        status = gameObject.GetComponent<TrapStatus>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerStatus playerStatus = other.GetComponent<PlayerStatus>();
        if (playerStatus)
        {
            if (playerStatus.getObjectElement() != status.getObjectElement())
            {
                playerStatus.setPlayerDead();
                Debug.Log("Morte");
            }
            else
            {
                Debug.Log("Passou pela trap de: " + status.getObjectElement());
            }
        }
    }
}

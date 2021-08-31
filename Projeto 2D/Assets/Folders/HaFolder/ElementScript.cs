using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class ElementScript : ElementalObjects
{
    private void Awake()
    {
        status = gameObject.GetComponent<ElementStatus>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerStatus playerStatus = other.GetComponent<PlayerStatus>();
        if (playerStatus)
        {
            playerStatus.setObjectElement(status.getObjectElement());
            Debug.Log("Elemento: " + status.getObjectElement());
        }
    }
}


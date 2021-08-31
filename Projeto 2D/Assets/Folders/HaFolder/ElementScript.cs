using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class ElementScript : ElementalObjects
{
    // Comportamento do elemento
    private void Awake()
    {
        status = gameObject.GetComponent<ElementStatus>();
    }
    
    /// <summary>
    /// Caso um GameObject que tenha o PlayerStatus passar pelo elemento, o elemento do PlayerStatus será
    /// atualizado para o elemento atual desse objecto.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerStatus playerStatus = other.GetComponent<PlayerStatus>();
        if (playerStatus)
        {
            playerStatus.setObjectElement(status.getObjectElement());
        }
    }
}


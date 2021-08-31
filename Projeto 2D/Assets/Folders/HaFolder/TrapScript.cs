using System;
using System.Collections;
using System.Collections.Generic;
using Folders.HaFolder;
using UnityEngine;

public class TrapScript : ElementalObjects
{
    // Comportamento da trap
    private void Awake()
    {
        status = gameObject.GetComponent<TrapStatus>();
    }
    
    /// <summary>
    /// Caso um GameObject que tenha o PlayerStatus passar pela trap, verifica-se se o elemento do PlayerStatus é o 
    /// mesmo desse objeto. Se sim, nada acontece e player passará. Se nao, o PlayerStatus será atualizado para morte
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerStatus playerStatus = other.GetComponent<PlayerStatus>();
        if (playerStatus)
        {
            if (playerStatus.getObjectElement() != status.getObjectElement())
            {
                playerStatus.setPlayerDead();
            }

        }
    }
}

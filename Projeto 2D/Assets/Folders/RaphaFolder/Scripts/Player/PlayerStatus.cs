using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class PlayerStatus : ObjectStatus
{
    [SerializeField] private Direction playerDirection; // player current direction
    [SerializeField] private bool isDead; // estado do jogador (vivo/morto)
    private void Awake()
    {
        setObjectElement(Element.ElementType.NONE);
        setObjectActivity(true);
        isDead = false;
    }
    
    /// <summary>
    /// Gets the direction of the current object (player)
    /// </summary>
    /// <returns>Direction of the object (player)</returns>
    public Direction getPlayerDirection() => playerDirection;
    /// <summary>
    /// Set the object Direction to the param
    /// </summary>
    /// <param name="element">Direction, desired direction of the object</param>
    public void setPlayerDirection(Direction direction) => playerDirection = direction;
    /// <summary>
    /// Verifica se o player está morto
    /// </summary>
    /// <returns>true - caso o player esteja morto</returns>
    public bool isPlayerDead() => isDead;
    /// <summary>
    /// Altera o estado de morte do jogador para true
    /// </summary>
    public void setPlayerDead() => isDead = true;
}

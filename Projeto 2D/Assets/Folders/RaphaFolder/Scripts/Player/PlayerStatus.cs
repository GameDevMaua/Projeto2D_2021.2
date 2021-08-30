using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : ObjectStatus
{
    [SerializeField]
    private Direction playerDirection; // player current direction
    private void Awake()
    {
        setObjectElement(Element.ElementType.NONE);
        setObjectActivity(true);
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
}

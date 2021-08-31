using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class PlayerStatus : ObjectStatus
{
    [SerializeField] private Direction playerDirection; // Direção para a qual o player está voltado atualmente
    [SerializeField] private bool isDead; // estado do jogador (vivo/morto)
    
    /// <summary>
    /// Inicializa variáveis com valores padrões
    /// </summary>
    private void Awake()
    {
        setObjectElement(Element.ElementType.NONE);
        setObjectActivity(true);
        isDead = false;
    }
    
    /// <summary>
    /// Lê a direção atual do objeto (player)
    /// </summary>
    /// <returns>Direction do objeto (player)</returns>
    public Direction getPlayerDirection() => playerDirection;
    /// <summary>
    /// Define a direção do objeto como o passado por parâmetro
    /// </summary>
    /// <param name="element">Direction, direção desejada para o objeto</param>
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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class PlayerStatus : ObjectStatus
{
    public Direction playerDirection; // Direção para a qual o player está voltado atualmente
    [SerializeField] private bool isDead; // estado do jogador (vivo/morto)
    public bool isWalking;
    
    /// <summary>
    /// Inicializa variáveis com valores padrões
    /// </summary>
    private void Awake()
    {
        setObjectElement(Element.ElementType.NONE);
        setObjectActivity(true);
        isDead = false;
        isWalking = false;
    }

    private void Update()
    {
        updateDirection();
        updateWalkingStatus();
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
    /// Atualiza em tempo real a direção para a qual o player está voltado.
    /// </summary>
    private void updateDirection()
    {
        setPlayerDirection(getPlayerDirection());
    }

    /// <summary>
    /// Atualiza se o player está ou não andando
    /// </summary>
    private void updateWalkingStatus()
    {
        switch (playerDirection)
        {
            case Direction.UP:
                isWalking = true;
                break;
            case Direction.DOWN:
                isWalking = true;
                break;
            case Direction.LEFT:
                isWalking = true;
                break;
            case Direction.RIGHT:
                isWalking = true;
                break;
            case Direction.UP_IDLE:
                isWalking = false;
                break;
            case Direction.DOWN_IDLE:
                isWalking = false;
                break;
            case Direction.LEFT_IDLE:
                isWalking = false;
                break;
            case Direction.RIGHT_IDLE:
                isWalking = false;
                break;
        }
    }
    
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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainProject.Scripts.Player
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Control Settings")]
        public KeyCode UpKey;
        public KeyCode DownKey;
        public KeyCode LeftKey;
        public KeyCode RightKey;
        public float Speed;
        public bool canMovePlayer = true;

        // Variáveis privadas
        private MainProject.Enums.Direction lastDirection;
        private Vector2 movementVector;
        private Rigidbody2D Rigidbody2DReference;
        private MainProject.Scripts.Player.PlayerStatus playerStatusReference;

        private void Awake()
        {
            // Definindo configurações padrões de atalhos de teclado
            if (UpKey == KeyCode.None) UpKey = KeyCode.W;
            if (DownKey == KeyCode.None) DownKey = KeyCode.S;
            if (LeftKey == KeyCode.None) LeftKey = KeyCode.A;
            if (RightKey == KeyCode.None) RightKey = KeyCode.D;
            
            // Definindo valores iniciais padrões
            if (lastDirection.Equals(null)) lastDirection = MainProject.Enums.Direction.NONE;
            if (Speed == 0f) Speed = 3.5f;
            
            // Atribuindo referência
            Rigidbody2DReference = GetComponent<Rigidbody2D>();
            playerStatusReference = gameObject.GetComponent<MainProject.Scripts.Player.PlayerStatus>();
            
        }

        private void Update()
        {
            if (canMovePlayer)
            {
                movementVector = MovementInputVector();
                MoveCharacter();
                playerStatusReference.setPlayerDirection(UpdateCurrentDirection());
            }
            else
            {
                movementVector = Vector2.zero;
                MoveCharacter();
            }
        }

        /// <summary>
        /// Executa a movimentação do personagem
        /// </summary>
        private void MoveCharacter()
        {
            Rigidbody2DReference.velocity = movementVector * Speed;
        }

        /// <summary>
        /// Realiza uma leitura da entrada do jogador e retorna um vetor
        /// </summary>
        /// <returns>Vector2, um vetor equivalente às teclas pressionadas</returns>
        private Vector2 MovementInputVector()
        {
            // Criação de um vetor
            var InputVector = Vector2.zero;
        
            // Leitura do eixo horizontal
            if (Input.GetKey(LeftKey))
                InputVector.x = -1f;
            else if (Input.GetKey(RightKey))
                InputVector.x = 1f;

            // Leitura do eixo vertical
            if (Input.GetKey(UpKey))
                InputVector.y = 1f;
            else if (Input.GetKey(DownKey))
                InputVector.y = -1f;

            // Devolve o novo vetor
            return InputVector.normalized;
        }
        
        /// <summary>
        /// Retorna a direção para a qual o player está voltado
        /// </summary>
        /// <returns>Direction, A direção atual para a qual o player está voltado</returns>
        private MainProject.Enums.Direction UpdateCurrentDirection()
        {
            // Correção de valores para o funcionamento do método
            var current = MainProject.Enums.Direction.NONE;
        
            // Verifica a movimentação horizontal
            if (movementVector.x > 0)
                current = MainProject.Enums.Direction.RIGHT;
            else if (movementVector.x < 0)
                current = MainProject.Enums.Direction.LEFT;

            // Verifica a movimentação vertical
            if (movementVector.y > 0)
                current = MainProject.Enums.Direction.UP;
            else if (movementVector.y < 0)
                current = MainProject.Enums.Direction.DOWN;

            // Verifica se o player está parado
            if (movementVector.magnitude == 0)
                current = lastDirection switch
                {
                    MainProject.Enums.Direction.RIGHT => MainProject.Enums.Direction.RIGHT_IDLE,
                    MainProject.Enums.Direction.LEFT => MainProject.Enums.Direction.LEFT_IDLE,
                    MainProject.Enums.Direction.UP => MainProject.Enums.Direction.UP_IDLE,
                    MainProject.Enums.Direction.DOWN => MainProject.Enums.Direction.DOWN_IDLE,
                    MainProject.Enums.Direction.RIGHT_IDLE => MainProject.Enums.Direction.RIGHT_IDLE,
                    MainProject.Enums.Direction.LEFT_IDLE => MainProject.Enums.Direction.LEFT_IDLE,
                    MainProject.Enums.Direction.UP_IDLE => MainProject.Enums.Direction.UP_IDLE,
                    MainProject.Enums.Direction.DOWN_IDLE => MainProject.Enums.Direction.DOWN_IDLE,
                    _ => current
                };

            // Verifica o caso inicial
            if (lastDirection == MainProject.Enums.Direction.NONE)
                current = MainProject.Enums.Direction.RIGHT;

            // Atualiza a última direção
            lastDirection = current;
        
            return current;
        }

        public void ChangeUpKey(KeyCode newKey) => UpKey = newKey;
        public void ChangeDownKey(KeyCode newKey) => DownKey = newKey;
        public void ChangeRightKey(KeyCode newKey) => RightKey = newKey;
        public void ChangeLeftKey(KeyCode newKey) => LeftKey = newKey;
    }
}

    


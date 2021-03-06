using UnityEngine;
using System;
using System.Collections.Generic;


namespace MainProject.Scripts
{
    public class MovementManager : MonoBehaviour
    {
        public float destinyPrecision = 0.2f; // Move o player para a posição designada +- destinyPrecision
        [SerializeField] private List<Movement> movementQueue;
        private float realTime;

        private float startTimeOfDelay;
        private bool hasStartedTimeOfDelay;

        private void Awake()
        {
            foreach (var VARIABLE in movementQueue)
            {
                VARIABLE.counter = 0;
                VARIABLE.speedStatus = false;
                VARIABLE.hasReached = false;
            }

            verifyListIntegrity(movementQueue);

            startTimeOfDelay = 0f;
            hasStartedTimeOfDelay = false;
        }

        private void Update()
        {
            realTime = Time.realtimeSinceStartup;
            foreach (var VARIABLE in movementQueue)
            {
                updatePosition(VARIABLE);
            }

            verifyListIntegrity(movementQueue);
        }

        /// <summary>
        /// Avalia as condições de início da movimentação e inicia de acordo com os parâmetros
        /// </summary>
        /// <param name="data">Movement, o ponto para o qual o player irá com detalhes</param>
        private void updatePosition(Movement data)
        {
            if (data.counter >= data.destinyPosition.Count) return; // Evita acesso de índice que não existe

            if (data.hasTriggerToStart[data.counter])
            {
                if (data.triggerToStart[data.counter]) startMovingObject(data);
            }
            else
            {
                if (!hasStartedTimeOfDelay)
                {
                    startTimeOfDelay = realTime;
                    hasStartedTimeOfDelay = true;
                }

                if (data.waitTimeBeforeStarting[data.counter] > realTime - startTimeOfDelay) return;
                startMovingObject(data);
            }


        }

        /// <summary>
        /// Inicia a movimentação do jogador.
        /// </summary>
        /// <param name="data">Movement, o ponto para o qual o player irá com detalhes</param>
        private void startMovingObject(Movement data)
        {
            var currentPosition = data._object.transform.position;
            if (data.speedStatus)
            {
                if (currentPosition == data.destinyPosition[data.counter] ||
                    (data.destinyPosition[data.counter] - currentPosition).magnitude < destinyPrecision)
                {
                    data.hasReached = true;
                }

                if (!data.hasReached)
                {
                    data._object.transform.position += data.currentSpeed;
                }
                else if (data.counter + 1 >= data.destinyPosition.Count)
                {
                    // Para a movimentação
                    oldDirectionInIdle(data);
                    data.counter++;
                    data.hasReached = true;
                    hasStartedTimeOfDelay = false;
                }
                else
                {
                    oldDirectionInIdle(data);
                    data.counter++;
                    data.speedStatus = false;
                    data.hasReached = false;
                    hasStartedTimeOfDelay = false;
                }
            }
            else
            {
                data.currentSpeed = (data.destinyPosition[data.counter] - currentPosition); // Vetor completo da direção
                calculateDirection(data);
                data.currentSpeed /= data.timeBeforeReachDestiny[data.counter]; // Versor da direção
                data.speedStatus = true;
            }
        }

        private void calculateDirection(Movement data)
        {
            var vectorX = data.currentSpeed.x;
            var vectorY = data.currentSpeed.y;
            var vectorZ = data.currentSpeed.z;

            if (vectorY > 0) data._objectDirection = MainProject.Enums.Direction.UP;
            else if (vectorY < 0) data._objectDirection = MainProject.Enums.Direction.DOWN;
            else if (vectorX > 0) data._objectDirection = MainProject.Enums.Direction.RIGHT;
            else if (vectorX < 0) data._objectDirection = MainProject.Enums.Direction.LEFT;
            else oldDirectionInIdle(data);
        }

        private void oldDirectionInIdle(Movement data)
        {
            switch (data._objectDirection)
            {
                case MainProject.Enums.Direction.UP:
                    data._objectDirection = MainProject.Enums.Direction.UP_IDLE;
                    break;
                case MainProject.Enums.Direction.DOWN:
                    data._objectDirection = MainProject.Enums.Direction.DOWN_IDLE;
                    break;
                case MainProject.Enums.Direction.LEFT:
                    data._objectDirection = MainProject.Enums.Direction.LEFT_IDLE;
                    break;
                case MainProject.Enums.Direction.RIGHT:
                    data._objectDirection = MainProject.Enums.Direction.RIGHT_IDLE;
                    break;
                default:
                    break;
            }
        }

        private void verifyListIntegrity(List<Movement> movements)
        {
            foreach (var move in movements)
            {
                var destinySize = move.destinyPosition.Count;
                var timeBeforeDestinySize = move.timeBeforeReachDestiny.Count;
                var hasTriggerSize = move.hasTriggerToStart.Count;
                var waitTimeSize = move.waitTimeBeforeStarting.Count;
                var triggerSizer = move.triggerToStart.Count;

                if (!(destinySize == timeBeforeDestinySize &&
                      timeBeforeDestinySize == hasTriggerSize &&
                      hasTriggerSize == waitTimeSize &&
                      waitTimeSize == triggerSizer))
                {
                    var max = findMax(new List<int>
                        {destinySize, timeBeforeDestinySize, hasTriggerSize, waitTimeSize, triggerSizer});
                    if (destinySize != max) move.destinyPosition.Add(Vector3.zero);
                    if (timeBeforeDestinySize != max) move.timeBeforeReachDestiny.Add(0f);
                    if (hasTriggerSize != max) move.hasTriggerToStart.Add(true);
                    if (waitTimeSize != max) move.waitTimeBeforeStarting.Add(0f);
                    if (triggerSizer != max) move.triggerToStart.Add(false);
                }
            }
        }

        private int findMax(IReadOnlyList<int> values)
        {
            var max = values[0];
            for (var i = 0; i < values.Count; i++)
            {
                if (values[i] > max) max = values[i];
            }

            return max;
        }

        /// <summary>
        /// Data class para a movimentação de um objeto genérico.
        /// Os campos destino, e tempos devem ser criados EM TRIOS.
        /// </summary>
        [Serializable]
        private class Movement
        {
            [Header("GameObject que será movimentado.")]
            public GameObject _object;

            public MainProject.Enums.Direction _objectDirection = MainProject.Enums.Direction.DOWN;

            [Header("Configurações principais (local e velocidade)")]
            public List<Vector3> destinyPosition;

            public List<float> timeBeforeReachDestiny;

            [Header("Controle de início da movimentação")]
            public List<bool> hasTriggerToStart;

            public List<float> waitTimeBeforeStarting;
            public List<bool> triggerToStart;


            [Header("Variáveis auxiliares internas do manager")]
            public Vector3 currentSpeed;

            public bool speedStatus;
            public bool hasReached;
            public int counter;
        }
    }
}
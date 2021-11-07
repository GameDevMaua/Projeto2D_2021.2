using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class MovementManager : MonoBehaviour
{
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
            if (data.waitTimeBeforeStarting[data.counter] > realTime-startTimeOfDelay) return;
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
            if (currentPosition == data.destinyPosition[data.counter])
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
                data.counter++;
                data.hasReached = true;
                hasStartedTimeOfDelay = false;
            }
            else
            {
                data.counter++;
                data.speedStatus = false;
                data.hasReached = false;
                hasStartedTimeOfDelay = false;
            }
        }
        else
        {
            data.currentSpeed = (data.destinyPosition[data.counter] - currentPosition) /
                                data.timeBeforeReachDestiny[data.counter];
            data.speedStatus = true;
        }
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

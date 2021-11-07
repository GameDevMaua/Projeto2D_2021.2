using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class MovementManager : MonoBehaviour
{
    [SerializeField] private List<Movement> movementQueue;
    
    private void Awake()
    {
        foreach (var VARIABLE in movementQueue)
        {
            VARIABLE.counter = 0;
            VARIABLE.speedStatus = false;
        }
    }
    
    private void Update()
    {
        foreach (var VARIABLE in movementQueue)
        {
            updatePosition(VARIABLE);
        }       
    }

    private void updatePosition(Movement data)
    {
        var currentPosition = data._object.transform.position;
        if (!(data.counter <= data.destinyPosition.Count)) return;
        if (!currentPosition.Equals(data.destinyPosition[data.counter])) // Verifica se o objeto chegou ao destino
            if (data.speedStatus) // Verifica se a velocidade do objeto para chegar no destino já foi calculada
                data._object.transform.position += data.currentSpeed;
            else // Calcula a velocidade do objeto para chegar no destino
            {
                data.currentSpeed = (data.destinyPosition[data.counter] - currentPosition) /
                                    data.timeBeforeReachDestiny[data.counter];
                data.speedStatus = true;
            }
        else
        {
            data.counter++;
            data.speedStatus = false;
        }
    }

    /// <summary>
    /// Data class para a movimentação de um objeto genérico.
    /// Os campos destino, e tempos devem ser criados EM TRIOS.
    /// </summary>
    [Serializable]
    private class Movement
    {
        public GameObject _object;
        [Header("Preencher os 3 vetores abaixo para cada ponto.")]
        public List<Vector3> destinyPosition;
        public List<float> timeBeforeReachDestiny;
        public List<float> waitTimeBeforeStarting;

        [Header("Variáveis auxiliares internas do manager")]
        public Vector3 currentSpeed;
        public bool speedStatus;
        public int counter;
    }
}

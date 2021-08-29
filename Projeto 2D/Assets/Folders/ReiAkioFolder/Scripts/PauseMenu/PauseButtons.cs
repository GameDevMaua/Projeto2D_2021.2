using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseButtons : MonoBehaviour
{
    [SerializeField] private GameObject setSelectedButton;
    
    /// <summary>
    ///  Este Update() passa a funcionar quando o pauseMenu esta ativado. Detecta o botao escolhido e
    /// o deixa selecionado para o funcionamento no teclado.
    /// </summary>
    private void Update()
    {
        if (GameObject.ReferenceEquals(EventSystem.current.currentSelectedGameObject, null))
        {
            EventSystem.current.SetSelectedGameObject(setSelectedButton);
        }
    }
}

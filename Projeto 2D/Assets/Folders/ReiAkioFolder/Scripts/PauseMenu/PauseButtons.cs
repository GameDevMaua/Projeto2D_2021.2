using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseButtons : MonoBehaviour
{
    [SerializeField] private GameObject setSelectedButton;
    public PauseMenu pM = new PauseMenu();
    
    
    /// <summary>
    /// Quando chamado, o metodo ira desativar o painel do pauseMenu e voltar o jogo ao seu devido tempo.
    /// </summary>
    public void ResumeButton()
    {
        pM.pauseMenu.SetActive(false);
        Time.timeScale = 1;
        pM.isPaused = false;
    }
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

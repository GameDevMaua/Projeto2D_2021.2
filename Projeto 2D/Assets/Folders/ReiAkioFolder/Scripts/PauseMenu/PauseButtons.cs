using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseButtons : MonoBehaviour
{
    public PauseMenu pM = new PauseMenu();
    public GameObject pausemenu;
    public GameObject changeKeyButton;
    
    /// <summary>
    /// Quando chamado, o metodo ira desativar o painel do pauseMenu e voltar o jogo ao seu devido tempo.
    /// </summary>
    public void ResumeButton()
    {
        pM.pauseMenu.SetActive(false);
        Time.timeScale = 1;
        pM.isPaused = false;
    }
    
    public void ChangeKeyButton(GameObject firstChangeKeyButton)
    {
        pausemenu.SetActive(false);
        changeKeyButton.SetActive(true);
        EventSystem.current.SetSelectedGameObject(firstChangeKeyButton);
    }
    
}


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenu;
    public bool isPaused;
    
    /// <summary>
    /// Quando chamado, ira ativar o painel do menuPause, e pausar o estado do jogo
    /// </summary>
    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;

    }
    /// <summary>
    /// Quando chamado, ira desativar o painel do menuPause, e despausar o estado do jogo.
    /// </summary>
    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    
    /// <summary>
    ///  Ao inicio, declara a variavel  isPaused para false.
    /// </summary>
    private void Start()
    {
        isPaused = false;
    }
    
    /// <summary>
    /// Quando chamado, o metodo ira desativar o painel do pauseMenu e voltar o jogo ao seu devido tempo.
    /// </summary>
    public void ResumeButton()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }


    /// <summary>
    /// Update() responsável por checar quando o "player" pressionar a tecla "esc", ao ser
    /// pressionado, ira checar se a variavel isPaused for verdadeira, se estiver ira chamar o metodo "Resume()"
    /// e "setar" a variavel para false. Caso a mesma esteja falsa, chama-se o metodo "Pause()" e torna verdadeira
    /// a variavel isPaused.
    /// </summary>
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
                isPaused = false;
            }
            else if (isPaused == false)
            {
                Pause();
                isPaused = true;
            }
        }
    }
}

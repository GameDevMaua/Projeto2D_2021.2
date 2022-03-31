using System;
using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenu;
    public bool isPaused;
    [SerializeField] public KeyCode openPMButton;
    public MainProject.Scripts.GameManager gameManager;
    [SerializeField] private string soundPath;
    
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
    public void Start()
    {
        isPaused = false;
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<MainProject.Scripts.GameManager>();
    }
    
    /// <summary>
    ///  Método reservado para a chamada do menu de pause ao apertar a tecla escolhida
    /// </summary>
    public void OpenMenu()
    {
        if (Input.GetKeyDown(openPMButton))
        {
            RuntimeManager.CreateInstance(soundPath).start();
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

    /// <summary>
    /// Update() responsável por checar quando o "player" pressionar a tecla "esc", ao ser
    /// pressionado, ira checar se a variavel isPaused for verdadeira, se estiver ira chamar o metodo "Resume()"
    /// e "setar" a variavel para false. Caso a mesma esteja falsa, chama-se o metodo "Pause()" e torna verdadeira
    /// a variavel isPaused.
    /// </summary>
    public void Update()
    {
        OpenMenu();
    }
}

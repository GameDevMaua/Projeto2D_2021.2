using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

//using UnityEditor;

public class PauseButtons : MonoBehaviour
{
    public PauseMenu pM;
    public GameObject pausemenu;
    public GameObject optionButton;
    
    /// <summary>
    /// Quando chamado, o metodo ira desativar o painel do pauseMenu e voltar o jogo ao seu devido tempo.
    /// </summary>
    public void ResumeButton()
    {
        string path = "event:/SFX/UI/sfx_ui_menu_button_confirm";
        EventInstance soundInstance = RuntimeManager.CreateInstance(path);
        soundInstance.start();
        pM.pauseMenu.SetActive(false);
        Time.timeScale = 1;
        pM.isPaused = false;
    }
    
    public void ChangeKeyButton(GameObject firstChangeKeyButton)
    {
        string path = "event:/SFX/UI/sfx_ui_menu_button_confirm";
        EventInstance soundInstance = RuntimeManager.CreateInstance(path);
        soundInstance.start();
        pausemenu.SetActive(false);
        optionButton.SetActive(true);
        EventSystem.current.SetSelectedGameObject(firstChangeKeyButton);
    }
 
    public void ReturnToMainMenu(string newScene)
    {
        string path = "event:/SFX/UI/sfx_ui_menu_button_back";
        EventInstance soundInstance = RuntimeManager.CreateInstance(path);
        soundInstance.start();
        pM.gameManager.LoadLevel(newScene);
        //SceneManager.LoadScene(newScene);
        Time.timeScale = 1;
    }
    
}
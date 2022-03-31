using System;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.EventSystems;
//#if UNITY_EDITOR
using UnityEditor;
//#endif

public class MainMenu : MonoBehaviour
{
    public GameObject firstButton;
    public GameObject mainMenu;
    public GameObject optionMenu;
    public GameObject firstOptionButton;
    private FirstButton fb;
    public MainProject.Scripts.GameManager gameManager;
    
    //#if UNITY_EDITOR
    //public SceneAsset scene;
    //#endif
    public string scene;

    public Animator animator;
    

    public void Start()
    {
        fb = mainMenu.AddComponent<FirstButton>();
        var gameManagerObject = GameObject.FindWithTag("GameManager");
        if (gameManagerObject != null)
            gameManager = gameManagerObject.GetComponent<MainProject.Scripts.GameManager>();
    }
    /// <summary>
    /// Ativa o trigger para que a tela fique preta em animação
    /// </summary>
    // #if UNITY_EDITOR
    // public void fadeOutTrigger(SceneAsset newScene)
    // {
    //     scene = newScene;
    //     animator.SetTrigger("FadeOut");
    // }
    // #endif
    public void fadeOutTrigger(string newScene)
        {
            string path = "event:/SFX/UI/sfx_ui_menu_button_confirm";
            EventInstance soundInstance = RuntimeManager.CreateInstance(path);
            soundInstance.start();
            scene = newScene;
            animator.SetTrigger("FadeOut");
        }

    /// <summary>
    /// Criação da ação do botão OPTION
    /// </summary>
    public void Option()
    {
        string path = "event:/SFX/UI/sfx_ui_menu_button_confirm";
        EventInstance soundInstance = RuntimeManager.CreateInstance(path);
        soundInstance.start();
        optionMenu.SetActive(true);
        mainMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(firstOptionButton);
    }

    /// <summary>
    /// Criação da ação do botão QUIT
    /// </summary>
    public void QuitGame()
    {
        string path = "event:/SFX/UI/sfx_ui_menu_button_back";
        EventInstance soundInstance = RuntimeManager.CreateInstance(path);
        soundInstance.start();
        Application.Quit();
        Debug.Log("QUIT");
    }

    /// <summary>
    /// realiza a ação da função do SelectFirstButton, na classe FirstButton
    /// </summary>
    public void Update()
    {
        fb.SelectFirstButton(firstButton);

    }
}
using UnityEngine;
using UnityEngine.EventSystems;

//using UnityEditor;

namespace MainProject.Scripts
{
    public class MainMenu : MonoBehaviour
    
{
    public GameObject firstButton;
    public GameObject mainMenu;
    public GameObject optionMenu;
    public GameObject firstOptionButton;
    private MainProject.Scripts.FirstButton fb;
    public string scene;

    public Animator animator;

    public void Start()
    {
        fb = mainMenu.AddComponent<FirstButton>();
    }
/// <summary>
/// Ativa o trigger para que a tela fique preta em animação
/// </summary>
    public void fadeOutTrigger(string newScene)
    {
        scene = newScene;
        animator.SetTrigger("FadeOut");
    }


    /// <summary>
    /// Criação da ação do botão OPTION
    /// </summary>
    public void Option()
    {
        
        optionMenu.SetActive(true);
        mainMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(firstOptionButton);
    }

    /// <summary>
    /// Criação da ação do botão QUIT
    /// </summary>
    public void QuitGame()
    {
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
}
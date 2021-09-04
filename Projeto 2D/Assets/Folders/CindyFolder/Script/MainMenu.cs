using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject firstButton;
    public GameObject mainMenu;
    public GameObject optionMenu;
    public GameObject firstOptionButton;
    
    /// <summary>
    /// Criação da ação do botão PLAY
    /// </summary>
    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene");
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
        FirstButton fb = new FirstButton();
        fb.SelectFirstButton(firstButton);

    }
}
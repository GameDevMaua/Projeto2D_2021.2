using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject firstButton;
    public GameObject mainMenu;
    public GameObject optionMenu;
    public GameObject firstOptionButton;
    
    public void PlayGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Option()
    {
        
        optionMenu.SetActive(true);
        mainMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(firstOptionButton);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QUIT");
    }

    public void Update()
    {
        if (GameObject.ReferenceEquals(EventSystem.current.currentSelectedGameObject, null))
        {

            EventSystem.current.SetSelectedGameObject(firstButton);
        }

    }
}
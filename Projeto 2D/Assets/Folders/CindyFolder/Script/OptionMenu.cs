using UnityEngine;
using UnityEngine.EventSystems;
 
 
public class OptionMenu : MonoBehaviour
{
    public GameObject optionFirstButton;
    public GameObject mainMenu;
    public GameObject optionMenu;
    public GameObject optionButton;
     
    /// <summary>
    /// Quando começar essa classe, chamar o optionFirstButton
    /// </summary>
    public void Start()
    {
        EventSystem.current.SetSelectedGameObject(optionFirstButton);
        optionMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
 
    /// <summary>
    /// Criação da ação do botão BACK
    /// </summary>
    public void backButton ()
    {
        optionMenu.SetActive(false);
        mainMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(optionButton);
    }
     
    /// <summary>
    /// realiza a ação da função do SelectFirstButton, na classe FirstButton
    /// </summary>
    public void Update()
    {
        FirstButton fb = new FirstButton();
        fb.SelectFirstButton(optionFirstButton);
 
    }
}
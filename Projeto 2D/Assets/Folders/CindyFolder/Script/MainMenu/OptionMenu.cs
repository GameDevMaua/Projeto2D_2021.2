using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;


public class OptionMenu : MonoBehaviour
{
    public GameObject optionFirstButton;
    public GameObject mainMenu;
    public GameObject optionMenu;
    public GameObject optionButton;
    private FirstButton fb;
     
    /// <summary>
    /// Quando começar essa classe, chamar o optionFirstButton
    /// </summary>
    public void Start()
    {
        fb = optionMenu.AddComponent<FirstButton>();
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


    public void setFullscreen(bool isFullScreen)
    {
        if( isFullScreen ) Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        else Screen.fullScreenMode = FullScreenMode.Windowed;
    } 

    public void setQualityScreen(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
     
    /// <summary>
    /// realiza a ação da função do SelectFirstButton, na classe FirstButton
    /// </summary>
    public void Update()
    {
        fb.SelectFirstButton(optionFirstButton);
 
    }
}
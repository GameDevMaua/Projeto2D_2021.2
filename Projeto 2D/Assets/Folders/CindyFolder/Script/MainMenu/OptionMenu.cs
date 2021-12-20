using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;


public class OptionMenu : MonoBehaviour
{
    public GameObject optionFirstButton;
    public GameObject mainMenu;
    public GameObject optionButton;
    public GameObject ChangeKeyButton;
    private FirstButton fb;
     
    /// <summary>
    /// Quando começar essa classe, chamar o optionFirstButton
    /// </summary>
    public void Start()
    {
        fb = this.gameObject.AddComponent<FirstButton>();
        EventSystem.current.SetSelectedGameObject(optionFirstButton);
        this.gameObject.SetActive(true);
        mainMenu.SetActive(false);
    }
 
    /// <summary>
    /// Criação da ação do botão BACK
    /// </summary>
    public void backButton ()
    {
        this.gameObject.SetActive(false);
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

    public void changeKeyButton(GameObject firstChangeKeyButton)
    {
        this.gameObject.SetActive(false);
        ChangeKeyButton.SetActive(true);
        EventSystem.current.SetSelectedGameObject(firstChangeKeyButton);
    }
    
     
    /// <summary>
    /// realiza a ação da função do SelectFirstButton, na classe FirstButton
    /// </summary>
    public void Update()
    {
        fb.SelectFirstButton(optionFirstButton);

    }
}
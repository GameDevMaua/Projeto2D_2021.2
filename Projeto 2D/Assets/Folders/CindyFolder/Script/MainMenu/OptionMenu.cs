using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using TMPro;


public class OptionMenu : MonoBehaviour
{
    public GameObject optionFirstButton;
    public GameObject mainMenu;
    public GameObject optionButton;
    public GameObject ChangeKeyButton;
    private FirstButton fb;

    public List<ResItem> resolutions = new List<ResItem>();
    private int selectedResolution;

    public TMP_Text resolutionLabel;
     
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

    public void ResLeft()
    {
        selectedResolution--;
        if (selectedResolution < 0)
        {
            selectedResolution = 0;
        }
        
        UpdateResLabel();
    }

    public void ResRight()
    {
        selectedResolution++;
        if (selectedResolution > resolutions.Count - 1)
        {
            selectedResolution = resolutions.Count - 1;
        }
        
        UpdateResLabel();
    }

    public void UpdateResLabel()
    {
        resolutionLabel.text = resolutions[selectedResolution].horizontal.ToString() + " x " + resolutions[selectedResolution].vertical.ToString();
    }
     
    /// <summary>
    /// realiza a ação da função do SelectFirstButton, na classe FirstButton
    /// </summary>
    public void Update()
    {
        fb.SelectFirstButton(optionFirstButton);

    }
}

[System.Serializable]
public class ResItem
{
    public int horizontal, vertical;
}
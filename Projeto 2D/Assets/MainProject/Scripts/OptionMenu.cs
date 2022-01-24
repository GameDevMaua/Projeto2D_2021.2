using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using TMPro;
using Toggle = UnityEngine.UI.Toggle;


namespace MainProject.Scripts

{
    public class OptionMenu : MonoBehaviour
    {
        public GameObject optionFirstButton;
        public GameObject mainMenu;
        public GameObject optionButton;
        public GameObject ChangeKeyButton;
        private MainProject.Scripts.FirstButton fb;


        public bool res = false;
        public Toggle fullScreenTog;
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

            fullScreenTog.isOn = Screen.fullScreen;

            for (int i = 0; i < resolutions.Count; i++)
            {
                if (Screen.width == resolutions[i].horizontal && Screen.height == resolutions[i].vertical)
                {
                    res = true;
                    selectedResolution = i;
                    UpdateResLabel();
                }
            }

            if (!res)
            {
                ResItem newResItem = new ResItem();
                newResItem.horizontal = Screen.width;
                newResItem.vertical = Screen.height;

                resolutions.Add(newResItem);

                selectedResolution = resolutions.Count - 1;

                UpdateResLabel();
            }

        }

        /// <summary>
        /// Criação da ação do botão BACK
        /// </summary>
        public void backButton()
        {
            this.gameObject.SetActive(false);
            mainMenu.SetActive(true);
            EventSystem.current.SetSelectedGameObject(optionButton);
        }


        public void setFullscreen(bool isFullScreen)
        {
            if (isFullScreen) Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
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
            resolutionLabel.text = resolutions[selectedResolution].horizontal.ToString() + " x " +
                                   resolutions[selectedResolution].vertical.ToString();
        }

        public void Apply()
        {
            Screen.SetResolution(resolutions[selectedResolution].horizontal, resolutions[selectedResolution].vertical,
                fullScreenTog.isOn);
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
}
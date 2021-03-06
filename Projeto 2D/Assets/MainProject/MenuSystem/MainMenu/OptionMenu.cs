using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MainProject.MenuSystem.MainMenu
{
    public class OptionMenu : MonoBehaviour
    {
        public GameObject optionFirstButton;
        public GameObject mainMenu;
        public GameObject optionMenu;
        public GameObject optionButton;
        private MainProject.MenuSystem.MainMenu.FirstButton fb;
     
        /// <summary>
        /// Quando começar essa classe, chamar o optionFirstButton
        /// </summary>
        public void Start()
        {
            fb = optionMenu.AddComponent<MainProject.MenuSystem.MainMenu.FirstButton>();
            EventSystem.current.SetSelectedGameObject(optionFirstButton);
            optionMenu.SetActive(true);
            mainMenu.SetActive(false);
        }
 
        /// <summary>
        /// Criação da ação do botão BACK
        /// </summary>
        public void backButton ()
        {
            string path = "event:/SFX/UI/sfx_ui_menu_button_confirm";
            EventInstance soundInstance = RuntimeManager.CreateInstance(path);
            soundInstance.start();
            optionMenu.SetActive(false);
            mainMenu.SetActive(true);
            EventSystem.current.SetSelectedGameObject(optionButton);
        }
     
        /// <summary>
        /// realiza a ação da função do SelectFirstButton, na classe FirstButton
        /// </summary>
        public void Update()
        {
            fb.SelectFirstButton(optionFirstButton);
 
        }
    }
}
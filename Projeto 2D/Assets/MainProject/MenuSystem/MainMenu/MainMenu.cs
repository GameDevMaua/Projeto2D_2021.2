#if UNITY_EDITOR
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

using UnityEditor;

namespace MainProject.MenuSystem.MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        public GameObject firstButton;
        public GameObject mainMenu;
        public GameObject optionMenu;
        public GameObject firstOptionButton;
        private MainProject.MenuSystem.MainMenu.FirstButton fb;
        private Scripts.GameManager gameManager;
        

        public void Start()
        {
            gameManager = GameObject.FindWithTag("GameManager").GetComponent<Scripts.GameManager>();
            fb = mainMenu.AddComponent<MainProject.MenuSystem.MainMenu.FirstButton>();
        }

        /// <summary>
        /// Criação da ação do botão PLAY
        /// </summary>
        public void PlayGame(SceneAsset newScene)
        {
            gameManager.LoadLevel(newScene.name);
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
#endif
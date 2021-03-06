#if UNITY_EDITOR
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

using UnityEditor;


namespace MainProject.Scripts
{
    public class PauseButtons : MonoBehaviour
    {
        public PauseMenu pM = new PauseMenu();
        public GameObject pausemenu;
        public GameObject optionButton;
    
        /// <summary>
        /// Quando chamado, o metodo ira desativar o painel do pauseMenu e voltar o jogo ao seu devido tempo.
        /// </summary>
        public void ResumeButton()
        {
            pM.pauseMenu.SetActive(false);
            Time.timeScale = 1;
            pM.isPaused = false;
        }
    
        public void ChangeKeyButton(GameObject firstChangeKeyButton)
        {
            pausemenu.SetActive(false);
            optionButton.SetActive(true);
            EventSystem.current.SetSelectedGameObject(firstChangeKeyButton);
        }
 
        public void ReturnToMainMenu(SceneAsset newScene)
        {
            SceneManager.LoadScene(newScene.name);
            Time.timeScale = 1;
        }
    
    }
}
#endif
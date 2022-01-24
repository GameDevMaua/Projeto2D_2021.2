using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainProject.Scripts
{
    public class NewScene : MonoBehaviour
    {
        public MainProject.Scripts.MainMenu mainMenu;
        public MainProject.Scripts.GameManager gameManager;
        
        
        public void PlayGame(SceneAsset newScene)
        {
            if(mainMenu != null)
                SceneManager.LoadScene(mainMenu.scene.name);
            if(gameManager != null)
                SceneManager.LoadScene(gameManager.nextLevel.name);
        }

    }
}
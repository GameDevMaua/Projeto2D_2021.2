
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class NewScene : MonoBehaviour
{
    public MainMenu mainMenu;
    public MainProject.Scripts.GameManager gameManager;
    #if UNITY_EDITOR
    public void PlayGame(SceneAsset newScene)
    {
        if(mainMenu != null)
            SceneManager.LoadScene(mainMenu.scene.name);
        if(gameManager != null)
            SceneManager.LoadScene(gameManager.nextLevel.name);
    }
    #endif

}
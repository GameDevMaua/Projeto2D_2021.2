
using UnityEngine;
using UnityEngine.SceneManagement;
// #if UNITY_EDITOR
// using UnityEditor;
// #endif

public class NewScene : MonoBehaviour
{
    public MainMenu mainMenu;
    
    // #if UNITY_EDITOR
    // public void PlayGame(SceneAsset newScene)
    // {
    //     if(mainMenu != null)
    //         SceneManager.LoadScene(mainMenu.scene.name);
    //     if(gameManager != null)
    //         SceneManager.LoadScene(gameManager.nextLevel.name);
    // }
    // #endif
    public void PlayGame(string newScene)
    {
        var called = false;
        if (mainMenu != null && called == false)
        {
            mainMenu.gameManager.LoadLevel(mainMenu.scene);
            called = true;
        }

        if (mainMenu.gameManager != null && called == false)
            mainMenu.gameManager.LoadLevel(mainMenu.gameManager.nextLevel);
    }

}
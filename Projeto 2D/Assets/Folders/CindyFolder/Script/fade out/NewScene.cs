using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewScene : MonoBehaviour
{
    public MainMenu mainMenu;
    public Animator animator;
    public void PlayGame(SceneAsset newScene)
    {
        SceneManager.LoadScene(mainMenu.scene.name);
    }

}

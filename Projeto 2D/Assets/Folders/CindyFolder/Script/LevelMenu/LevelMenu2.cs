using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu2 : MonoBehaviour
{
    public GameObject firstButton;
    public void ChangeScene(String newScene)
    {
        SceneManager.LoadScene(newScene);
    }
    
    public void Update()
    {
        FirstButton fb = gameObject.AddComponent<FirstButton>();
        fb.SelectFirstButton(firstButton);

    }
}

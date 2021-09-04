using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu2Script : MonoBehaviour
{
    public GameObject firstButton;
    public String newScene;
    
    public void ChangeScene()
    {
        SceneManager.LoadScene(newScene);
    }
    
    public void Update()
    {
        FirstButton fb = new FirstButton();
        fb.SelectFirstButton(firstButton);

    }
}

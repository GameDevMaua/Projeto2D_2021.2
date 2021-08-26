using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenu;
    public void pause()
    {

        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        
        
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pause();
        }
    }
}

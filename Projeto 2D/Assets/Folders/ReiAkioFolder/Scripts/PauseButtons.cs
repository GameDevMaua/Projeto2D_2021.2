using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButtons : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenu; 
    
    public void resumeButton()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }
}

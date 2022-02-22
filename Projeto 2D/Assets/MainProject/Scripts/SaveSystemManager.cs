using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using FirstButton = MainProject.Scripts.FirstButton;


public class SaveSystemManager : MonoBehaviour
{
    [SerializeField] private string reachedScene;
    public GameObject[] levelPages;
    public GameObject[] back;

    private void Awake()
    {
        levelPages[0].SetActive(false);
        levelPages[1].SetActive(false);
        levelPages[2].SetActive(false);
        levelPages[3].SetActive(false);
        levelPages[4].SetActive(false);
        levelPages[5].SetActive(false);
        levelPages[6].SetActive(false);
        //reachedScene = SaveSystem.LoadData().savedScene;
        
        //mainMenu = gameObject.GetComponent<MainMenu>();
    }

    private void Start()
    {
        showLevelPage();
    }

    private void showLevelPage()
    {
        var reloadedData = MainProject.Scripts.SaveSystem.LoadData();
        if (reloadedData == null)
        {
            levelPages[6].SetActive(true);
            EventSystem.current.SetSelectedGameObject(back[6]);
            return;
        }
        
        var level = char.GetNumericValue(reloadedData.savedScene[0]);
        switch (level)
        {
            case (0):
                levelPages[0].SetActive(true);
                EventSystem.current.SetSelectedGameObject(back[0]);
                break;
            case (1):
                levelPages[0].SetActive(true);
                EventSystem.current.SetSelectedGameObject(back[0]);
                break;
            case (2):
                levelPages[1].SetActive(true);
                EventSystem.current.SetSelectedGameObject(back[1]);
                break;
            case (3):
                levelPages[1].SetActive(true);
                EventSystem.current.SetSelectedGameObject(back[1]);
                break;
            case (4):
                levelPages[2].SetActive(true);
                EventSystem.current.SetSelectedGameObject(back[2]);
                break;
            case (5):
                levelPages[2].SetActive(true);
                EventSystem.current.SetSelectedGameObject(back[2]);
                break;
            case (6):
                levelPages[3].SetActive(true);
                EventSystem.current.SetSelectedGameObject(back[3]);
                break;
            case (7):
                levelPages[3].SetActive(true);
                EventSystem.current.SetSelectedGameObject(back[3]);
                break;
            case (8):
                levelPages[4].SetActive(true);
                EventSystem.current.SetSelectedGameObject(back[4]);
                break;
            case (9):
                levelPages[5].SetActive(true);
                EventSystem.current.SetSelectedGameObject(back[5]);
                break;
            default:
                levelPages[6].SetActive(true);
                EventSystem.current.SetSelectedGameObject(back[6]);
                break;
        }
    }

    // private void correctLevelsShown()
    // {
    //     MainProject.Scripts.PlayerData reloadedData = MainProject.Scripts.SaveSystem.LoadData();
    //     for (int j = 0; j < levelPages.Length; j++)
    //     {
    //         if (reloadedData == null)
    //             GameObject.Find("levePage Back");
    //
    //         else
    //         {
    //             if (char.GetNumericValue(reloadedData.savedScene[0]) >=
    //                 int.Parse(levelPages[j].name.Substring(levelPages[j].name.Length - 1)))
    //             {
    //                 Debug.Log(levelPages[j] + "nome da cena");
    //                 levelPages[j].SetActive(true);
    //             }
    //         }
    //     }
    //     
    // }
}

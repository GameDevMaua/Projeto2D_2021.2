using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;


public class SaveSystemManager : MonoBehaviour
{
    [SerializeField] private string reachedScene;
    public GameObject[] levelPages;
    public MainMenu mainMenu;
    public MainProject.Scripts.FirstButton fb;
    public List<GameObject> back = new List<GameObject>();

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
        for (int i = 0; i < levelPages.Length; i++)
        {
            var index1 = (levelPages[i].transform.childCount);
            var index2 = (levelPages[i].transform.GetChild(index1-1).childCount);
            var temp = levelPages[i].transform.GetChild(index1-1).GetChild(index2-1).gameObject;
            back.Add(temp);
        }
        
        showLevelPage();
        
    }

    private void showLevelPage()
    {
        MainProject.Scripts.PlayerData reloadedData = MainProject.Scripts.SaveSystem.LoadData();
        switch (char.GetNumericValue(reloadedData.savedScene[0]))
        {
            case (0):
                levelPages[0].SetActive(true);
                fb.SelectFirstButton(back[0]);
                break;
            case (1):
                levelPages[0].SetActive(true);
                fb.SelectFirstButton(back[0]);
                break;
            case (2):
                levelPages[1].SetActive(true);
                fb.SelectFirstButton(back[1]);
                break;
            case (3):
                levelPages[1].SetActive(true);
                fb.SelectFirstButton(back[1]);
                break;
            case (4):
                levelPages[2].SetActive(true);
                fb.SelectFirstButton(back[2]);
                break;
            case (5):
                levelPages[2].SetActive(true);
                fb.SelectFirstButton(back[2]);
                break;
            case (6):
                levelPages[3].SetActive(true);
                fb.SelectFirstButton(back[3]);
                break;
            case (7):
                levelPages[3].SetActive(true);
                fb.SelectFirstButton(back[3]);
                break;
            case (8):
                levelPages[4].SetActive(true);
                fb.SelectFirstButton(back[4]);
                break;
            case (9):
                levelPages[5].SetActive(true);
                fb.SelectFirstButton(back[5]);
                break;
            default:
                levelPages[6].SetActive(true);
                fb.SelectFirstButton(back[6]);
                break;
        }
    }

    private void correctLevelsShown()
    {
        MainProject.Scripts.PlayerData reloadedData = MainProject.Scripts.SaveSystem.LoadData();
        for (int j = 0; j < levelPages.Length; j++)
        {
            if (reloadedData == null)
                GameObject.Find("levePage Back");

            else
            {
                if (char.GetNumericValue(reloadedData.savedScene[0]) >=
                    int.Parse(levelPages[j].name.Substring(levelPages[j].name.Length - 1)))
                {
                    Debug.Log(levelPages[j] + "nome da cena");
                    levelPages[j].SetActive(true);
                }
            }
        }
        
    }
}

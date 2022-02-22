using System;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;


public class SaveSystemManager : MonoBehaviour
{
    [SerializeField] private string reachedScene;
    public GameObject[] levelPages;
    public MainMenu mainMenu;

    private void Awake()
    {
        //reachedScene = SaveSystem.LoadData().savedScene;
        correctLevelsShown();
        //mainMenu = gameObject.GetComponent<MainMenu>();
    }

    private void correctLevelsShown()
    {
        MainProject.Scripts.PlayerData reloadedData = MainProject.Scripts.SaveSystem.LoadData();
        for (int j = 0; j < levelPages.Length; j++)
        {
            if (reloadedData == null) 
                mainMenu.firstButton = GameObject.Find("Back");

            else
            {
                if (char.GetNumericValue(reloadedData.savedScene[0]) >=  int.Parse(levelPages[j].name.Substring(levelPages[j].name.Length - 1)))
                {
                    Debug.Log(levelPages[j] + "nome da cena");
                    levelPages[j].SetActive(true);
                }   
            }
        }
        
    }

    private void correctButtonNavigation()
    {
        
    }
}

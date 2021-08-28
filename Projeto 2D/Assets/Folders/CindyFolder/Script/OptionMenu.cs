using UnityEngine;
using UnityEngine.EventSystems;
 
 
public class OptionMenu : MonoBehaviour
{
    public GameObject optionFirstButton;
    public GameObject mainMenu;
    public GameObject optionMenu;
    public GameObject optionButton;
     
    public void Start()
    {
        EventSystem.current.SetSelectedGameObject(optionFirstButton);
        optionMenu.SetActive(true);
        mainMenu.SetActive(false);
    }
 
    public void backButton ()
    {
        optionMenu.SetActive(false);
        mainMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(optionButton);
    }
     
    public void Update()
    {
        if (ReferenceEquals(EventSystem.current.currentSelectedGameObject, null))
        {
 
            EventSystem.current.SetSelectedGameObject((optionFirstButton));
        }
 
    }
}
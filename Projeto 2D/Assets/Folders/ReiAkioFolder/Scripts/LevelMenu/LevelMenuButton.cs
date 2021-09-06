using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LevelMenuButton : MonoBehaviour
{
    [SerializeField] private GameObject setSelectedButton;
    private void selectedButton()
        {
            if (GameObject.ReferenceEquals(EventSystem.current.currentSelectedGameObject, null))
            {
                EventSystem.current.SetSelectedGameObject(setSelectedButton);
            }
        }
    void Update()
    {
        selectedButton();
    }
}

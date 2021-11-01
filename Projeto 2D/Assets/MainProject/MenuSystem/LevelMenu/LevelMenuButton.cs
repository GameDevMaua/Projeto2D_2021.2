using UnityEngine;
using UnityEngine.EventSystems;

namespace MainProject.MenuSystem.LevelMenu
{
    public class LevelMenuButton
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
}
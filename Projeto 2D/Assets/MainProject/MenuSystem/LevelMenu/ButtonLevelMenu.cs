using System;
using UnityEngine.SceneManagement;

namespace MainProject.MenuSystem.LevelMenu
{
    public class ButtonLevelMenu
    {
        public void faseButton(String fase)
        {
            SceneManager.LoadScene(fase);
        }
    }
}
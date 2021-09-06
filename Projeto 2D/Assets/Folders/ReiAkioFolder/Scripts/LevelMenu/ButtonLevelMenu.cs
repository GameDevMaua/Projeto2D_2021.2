using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonLevelMenu : MonoBehaviour
{
   public void faseButton(String fase)
   {
      SceneManager.LoadScene(fase);
   }
   
}

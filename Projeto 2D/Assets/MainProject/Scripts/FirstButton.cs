﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


namespace MainProject.Scripts
{
    public class FirstButton: MonoBehaviour
    {

        /// <summary>
        ///  Caso não tenha um botão selecionado, selecionar o firstButton
        /// </summary>
        /// <param name="firstButton"></param>
        public void SelectFirstButton(GameObject firstButton)
        {
            if (GameObject.ReferenceEquals(EventSystem.current.currentSelectedGameObject, null))
            {

                EventSystem.current.SetSelectedGameObject(firstButton);
            }
        }
    }
}
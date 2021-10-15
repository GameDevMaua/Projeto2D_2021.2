using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace MainProject.Scripts.Element
{
    public class ElementScript : MonoBehaviour
    {
        /// <summary>
        /// Caso um GameObject que tenha o PlayerStatus passar pelo elemento, o elemento do PlayerStatus será
        /// atualizado para o elemento atual desse objecto.
        /// </summary>
        /// <param name="other"></param>
        private void OnCollisionEnter2D(Collision2D other)
        {
            var playerStatus = other.gameObject.GetComponent<MainProject.Scripts.Player.PlayerStatus>();
            if (playerStatus)
            {
                var objectElement = gameObject.GetComponent<MainProject.Scripts.Element.ElementStatus>().getObjectElement();
                playerStatus.setObjectElement(objectElement);
            }
        }
    }
}


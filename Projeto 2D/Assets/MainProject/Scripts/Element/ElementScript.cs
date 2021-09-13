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
        private void OnTriggerEnter2D(Collider2D other)
        {
            var playerStatus = other.GetComponent<MainProject.Scripts.Player.PlayerStatus>();
            if (playerStatus)
            {
                var objectElement = gameObject.GetComponent<MainProject.Scripts.Element.ElementStatus>().getObjectElement();
                playerStatus.setObjectElement(objectElement);
            }
        }
    }
}


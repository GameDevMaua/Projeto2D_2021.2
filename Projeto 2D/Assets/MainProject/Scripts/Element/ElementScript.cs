using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Object = System.Object;

namespace MainProject.Scripts.Element
{
    public class ElementScript : MonoBehaviour
    {
        public float delayTime = 3f;
        public bool collectedStatus = false;
        public bool disableAndNotChangeStatus = true;
        
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
                StartCoroutine(DisableWithDelay(delayTime));
            }
        }
        
        private IEnumerator DisableWithDelay(float delay)
        {
            // Desativa ou altera o status para coletado
            if (disableAndNotChangeStatus) setObjectStatus(false);
            else collectedStatus = true;
            
            // Delay
            yield return new WaitForSeconds(delayTime);
            
            // Ativa ou altera o status para não coletado
            if (disableAndNotChangeStatus) setObjectStatus(true);
            else collectedStatus = false;
        }

        private void setObjectStatus(bool activeStatus)
        {
            gameObject.GetComponent<Animator>().enabled = activeStatus;
            gameObject.GetComponent<ElementAnimation>().enabled = activeStatus;
            gameObject.GetComponent<SpriteRenderer>().enabled = activeStatus;
            gameObject.GetComponent<BoxCollider2D>().enabled = activeStatus;
        }
    }
}


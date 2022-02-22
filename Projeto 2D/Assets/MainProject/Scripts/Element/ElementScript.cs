using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEditor;
using UnityEngine;
using Object = System.Object;

namespace MainProject.Scripts.Element
{
    public class ElementScript : MonoBehaviour
    {
        public float delayTime = 3f;
        public int higherLayer = 5;
        public int lowerLayer;
        public string sfxPath;

        private GameObject playerRef;
        private Animator animatorRef;
        private ElementAnimation elementAnimationRef;
        private SpriteRenderer spriteRendererRef;
        private BoxCollider2D boxCollider2DRef;
        private bool alternator;

        private void Awake()
        {
            playerRef = GameObject.FindWithTag("Player");
            animatorRef = gameObject.GetComponent<Animator>();
            elementAnimationRef = gameObject.GetComponent<ElementAnimation>();
            spriteRendererRef = gameObject.GetComponent<SpriteRenderer>();
            boxCollider2DRef = gameObject.GetComponent<BoxCollider2D>();
            alternator = false;
        }

        private void Update()
        {
            verificaPosicaoAtualizaSpriteOrder();
        }

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
                RuntimeManager.CreateInstance(sfxPath).start();
                var objectElement = gameObject.GetComponent<MainProject.Scripts.Element.ElementStatus>().getObjectElement();
                playerStatus.setObjectElement(objectElement);
                setObjectStatus(false);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            var playerStatus = other.gameObject.GetComponent<MainProject.Scripts.Player.PlayerStatus>();
            if (playerStatus)
            {
                StartCoroutine(enableWithDelay(delayTime));
            }
        }

        private IEnumerator enableWithDelay(float delay)
        {
            // Delay
            yield return new WaitForSeconds(delayTime);
            
            // Reativa o objeto
            setObjectStatus(true);
        }

        private void setObjectStatus(bool activeStatus)
        {
            animatorRef.enabled = activeStatus;
            elementAnimationRef.enabled = activeStatus;
            spriteRendererRef.enabled = activeStatus;
            boxCollider2DRef.isTrigger = !activeStatus;
        }

        private void verificaPosicaoAtualizaSpriteOrder()
        {
            if ((playerRef.transform.position.y > gameObject.transform.position.y) && !alternator)
            {
                spriteRendererRef.sortingOrder = higherLayer;
                alternator = true;
            }
            else if ((playerRef.transform.position.y <= gameObject.transform.position.y) && alternator)
            {
                spriteRendererRef.sortingOrder = lowerLayer;
                alternator = false;
            }
        }
    }
}


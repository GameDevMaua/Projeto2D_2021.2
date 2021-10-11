using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace MainProject.Scripts
{
    public class SwitchScript : MonoBehaviour
    {
        public List<GameObject> objectsPrimarySelection;
        public List<GameObject> objectsSecondarySelection;
        public KeyCode interactionKey;
        [SerializeField]
        private double interactionDistance = 5f;
        
        private bool switchBool;
        private GameObject playerRef;

        /// <summary>
        /// Chamada Awake da alavanca
        /// </summary>
        private void Awake()
        {
            playerRef = GameObject.FindWithTag("Player");
            switchBool = true;

            if (objectsPrimarySelection.Count != 0){ foreach (var VARIABLE in objectsPrimarySelection) VARIABLE.SetActive(switchBool);}
            if (objectsSecondarySelection.Count != 0) foreach (var VARIABLE in objectsSecondarySelection) VARIABLE.SetActive(!switchBool);
            if (interactionKey.Equals(KeyCode.None)) interactionKey = KeyCode.E;
            if (objectsPrimarySelection.Count == 0 && objectsSecondarySelection.Count == 0) Debug.Log("Nenhum objeto atribuído à switch: " + gameObject);
        }

        private void Update()
        {
            interactionVerify();
        }

        /// <summary>
        /// Retorna se o player está na distância correta de interação com a alavanca
        /// </summary>
        /// <returns>true - caso seja possível interagir </returns>
        private bool isThisObjectInInteractionRange()
        {
            return !((playerRef.transform.position - gameObject.transform.position).magnitude > interactionDistance);
        }

        /// <summary>
        /// Altera os objetos ativos na cena.
        /// </summary>
        private void switchActiveObjects()
        {
            switchBool = !switchBool;
            foreach (var VARIABLE in objectsPrimarySelection) VARIABLE.SetActive(switchBool);
            foreach (var VARIABLE in objectsSecondarySelection) VARIABLE.SetActive(!switchBool);
        }

        /// <summary>
        /// Verifica se houve interação com a alavanca
        /// </summary>
        private void interactionVerify()
        {
            if (Input.GetKeyUp(interactionKey) && isThisObjectInInteractionRange()) switchActiveObjects();
        }
    }
}

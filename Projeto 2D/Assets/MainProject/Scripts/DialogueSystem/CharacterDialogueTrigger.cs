

using System;
using UnityEngine;

namespace MainProject.Scripts.DialogueSystem
{
    /// <summary>
    /// O trigger do characterdialogue, ou seja, o dialogo é ativado quando o player se aproxima do gameobject e aparece o dialogo
    /// </summary>
    public class CharacterDialogueTrigger : MonoBehaviour
    {
        public GameObject entityCharacterDialogueGameObject;            // Game Object do characterDialogue da entidade do diálogo
        public CharacterDialogueManager entityCharacterDialogueManager; // Referência do Script do DialogueManager
        public bool aux;
        public Dialogue dialogue;
        
        private bool playerInRange;

        


        /// <summary>
        /// Funcao para comecar o diálogo
        /// </summary>
        public void TriggerDialogue()
        {
            FindObjectOfType<CharacterDialogueManager>().StartDialogue(dialogue);
            entityCharacterDialogueManager.FunctionToDeactivateDialogue();
        }
    
        /// <summary>
        /// Quando o player estiver dentro da área, comeca o diálogo
        /// </summary>
        public void Update()
        {
    
            if (playerInRange == true && aux == true) // se estiver dentro do playerInRange
            {
                if (entityCharacterDialogueManager.isDialogue == false)
                {
                    // Inicializa o diálogo, caso esse não esteja inicializado
                    TriggerDialogue();
                    aux = false;
    
                }
    
            }
            
            if (playerInRange == false)
            {
                aux = true;
            }
        }
            
        /// <summary>
        /// Quando o player estiver dentro da área, inicia o dialogo
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.attachedRigidbody)
            {
                playerInRange = true;
                entityCharacterDialogueGameObject.SetActive(true);
            }
    
        }
        
        /// <summary>
        /// Quando o player estiver fora da área, termina o dialogo
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.attachedRigidbody)
            {
                playerInRange = false;
                entityCharacterDialogueManager.EndDialogue();
            }
        }
    }
}
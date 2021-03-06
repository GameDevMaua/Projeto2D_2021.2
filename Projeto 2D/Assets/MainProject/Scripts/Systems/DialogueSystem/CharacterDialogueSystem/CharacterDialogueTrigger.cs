using UnityEngine;

namespace MainProject.Scripts.DialogueSystem.CharacterDialogueSystem
{
    public class CharacterDialogueTrigger : MonoBehaviour
    {
        public MainProject.Scripts.DialogueSystem.Dialogue dialogue;
        public MainProject.Scripts.DialogueSystem.CharacterDialogueSystem.CharacterDialogueManager characterDialogueManager;
        private bool playerInRange;
        public GameObject thisCharacterDialogue;
        public bool aux;
    
        /// <summary>
        /// Funcao para comecar o diálogo
        /// </summary>
        public void TriggerDialogue()
        {
            FindObjectOfType<CharacterDialogueManager>().StartDialogue(dialogue);
            characterDialogueManager.FunctionToDeactivateDialogue();
        }
    
        /// <summary>
        /// Quando o player estiver dentro da área, comeca o diálogo
        /// </summary>
        public void Update()
        {
    
            if (playerInRange == true && aux == true) // se estiver dentro do playerInRange
            {
                if (characterDialogueManager.isDialogue == false)
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
                thisCharacterDialogue.SetActive(true);
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
                characterDialogueManager.EndDialogue();
            }
        }
    }
}
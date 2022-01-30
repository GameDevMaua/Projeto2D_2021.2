using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MainProject.Scripts.Exclusivos
{
    public class InteractDialogueTrigger_Tutorial_7 : MonoBehaviour
    {
        

        public MainProject.Scripts.DialogueSystem.Dialogue dialogue;
        public MainProject.Scripts.DialogueSystem.InteractDialogueSystem.InteractDialogueManager interactDialogueManager;
        private bool playerInRange;
        public bool triggerDialogue = false;
        public bool hasInteracted = false;
        
        /// <summary>
        /// Funcao para comecar o diálogo
        /// </summary>
        public void TriggerDialogue()
        {
            FindObjectOfType<MainProject.Scripts.DialogueSystem.InteractDialogueSystem.InteractDialogueManager>().StartDialogue(dialogue);
        }

        /// <summary>
        /// Quando apertar "Z" dentro da área e o player estiver dentro da área, comeca o diálogo
        /// </summary>
        public void Update()
        {
            if (triggerDialogue) // se estiver dentro do playerInRange e for um dialogo normal
            {
                Debug.Log("Entrou no if");
                Time.timeScale = 0f;
                if (interactDialogueManager.isDialogue == false)
                {
                    // Inicializa o diálogo, caso esse não esteja inicializado
                    
                    Debug.Log("Entrou no segundo if");
                    TriggerDialogue();
                    Debug.Log("Executou o trigger dialogue");

                }
                else
                {
                    Debug.Log("Não entrou no seguno if");
                    interactDialogueManager
                        .DisplayNextSentence(); // Caso o diálogo esteja inicializado, vai para a próxima fala
                    Debug.Log("Mostrou a próxima cena");
                }
                Debug.Log("Resetou Trigger Dialogue");
                triggerDialogue = false;
                hasInteracted = true;
            }

            else
            {
                if (Input.GetKeyDown(interactDialogueManager.key) && playerInRange && hasInteracted) // se estiver dentro do playerInRange e for um dialogo normal
                {
                    Time.timeScale = 0f;
                    if(interactDialogueManager.isDialogue == false) // Inicializa o diálogo, caso esse não esteja inicializado
                        TriggerDialogue();
                    else
                        interactDialogueManager.DisplayNextSentence(); // Caso o diálogo esteja inicializado, vai para a próxima fala
                }
            }
        }
        
        /// <summary>
        /// Quando o player estiver dentro da área, inicia o dialogo
        /// <param name="other"></param>
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.attachedRigidbody)
            {
                playerInRange = true;
            }
    
        }
        
        /// <summary>
        /// Quando o player estiver fora da área, nao consegue iniciar o dialogo
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.attachedRigidbody)
            {
                playerInRange = false;
            }
        }

        public IEnumerator startDialogue(float delayTime)
        {
            yield return new WaitForSeconds(delayTime);
            triggerDialogue = true;
        }
        

    }
    }

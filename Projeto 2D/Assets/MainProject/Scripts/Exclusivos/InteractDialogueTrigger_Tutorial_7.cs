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
        public bool endedDialogue = false;
        
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
                Time.timeScale = 0f;
                if (interactDialogueManager.isDialogue == false && !endedDialogue)
                {
                    // Inicializa o diálogo, caso esse não esteja inicializado
                    TriggerDialogue();
                    endedDialogue = true;

                }
                else
                {
                    interactDialogueManager
                        .DisplayNextSentence(); // Caso o diálogo esteja inicializado, vai para a próxima fala
                }
                triggerDialogue = false;
                hasInteracted = true;
            }

            else
            {
                if (Input.GetKeyDown(interactDialogueManager.key) && playerInRange && hasInteracted || Input.GetKeyDown(KeyCode.Return) && playerInRange && hasInteracted) // se estiver dentro do playerInRange e for um dialogo normal
                {
                    Time.timeScale = 0f;
                    if (interactDialogueManager.isDialogue == false && !endedDialogue)
                    {
                        // Inicializa o diálogo, caso esse não esteja inicializado
                        TriggerDialogue();
                        endedDialogue = true;
                    }
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

        private IEnumerator startDialogueWithDelay(float delayTime)
        {
            yield return new WaitForSeconds(delayTime);
            triggerDialogue = true;
        }

        public void StartDialogue(float delay)
        {
            StartCoroutine(startDialogueWithDelay(delay));
        }
        

    }
    }

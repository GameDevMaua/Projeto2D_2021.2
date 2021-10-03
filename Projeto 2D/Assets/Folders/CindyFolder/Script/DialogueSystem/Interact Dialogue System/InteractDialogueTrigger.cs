using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractDialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public InteractDialogueManager interactDialogueManager;
    private bool playerInRange;

    /// <summary>
    /// Funcao para comecar o diálogo
    /// </summary>
    public void TriggerDialogue()
    {
        FindObjectOfType<InteractDialogueManager>().StartDialogue(dialogue);
    }

    /// <summary>
    /// Quando apertar "Z" dentro da área e o player estiver dentro da área, comeca o diálogo
    /// </summary>
    public void Update()
    {
        if (Input.GetKeyDown(interactDialogueManager.key) && playerInRange == true) // se estiver dentro do playerInRange e for um dialogo normal
        {
            Time.timeScale = 0f;
            if(interactDialogueManager.isDialogue == false) // Inicializa o diálogo, caso esse não esteja inicializado
                TriggerDialogue();
            else
                interactDialogueManager.DisplayNextSentence(); // Caso o diálogo esteja inicializado, vai para a próxima fala
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
}
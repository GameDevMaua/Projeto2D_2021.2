using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public CharacterDialogueManager characterDialogueManager;
    private bool playerInRange;
    public GameObject thisCharacterDialogue;

    /// <summary>
    /// Funcao para comecar o diálogo
    /// </summary>
    public void TriggerDialogue()
    {
        FindObjectOfType<CharacterDialogueManager>().StartDialogue(dialogue);
    }

    /// <summary>
    /// Quando apertar "Z" dentro da área e o player estiver dentro da área, comeca o diálogo
    /// </summary>
    public void Update()
    {

        if (playerInRange == true) // se estiver dentro do playerInRange e for um characterdialogue
        {
            if(characterDialogueManager.isDialogue == false) // Inicializa o diálogo, caso esse não esteja inicializado
                TriggerDialogue();

        }
        
    }
        
    /// <summary>
    /// Quando o player estiver dentro da área, aumenta o Gameobject da cena para saber que o player pode apertar "Z"
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
    /// Quando o player estiver fora da área, diminui o Gameobject da cena para saber que o player não consegue apertar "Z"
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
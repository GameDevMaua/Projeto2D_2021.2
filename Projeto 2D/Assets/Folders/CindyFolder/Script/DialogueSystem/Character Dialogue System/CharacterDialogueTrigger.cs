using UnityEngine;

/// <summary>
/// O trigger do characterdialogue, ou seja, o dialogo é ativado quando o player se aproxima do gameobject e aparece o dialogo
/// </summary>
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
    /// Quando o player estiver dentro da área, comeca o diálogo
    /// </summary>
    public void Update()
    {

        if (playerInRange == true) // se estiver dentro do playerInRange
        {
            if(characterDialogueManager.isDialogue == false) // Inicializa o diálogo, caso esse não esteja inicializado
                TriggerDialogue();

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
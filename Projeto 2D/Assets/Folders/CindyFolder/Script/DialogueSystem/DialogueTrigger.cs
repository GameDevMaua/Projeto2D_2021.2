using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public DialogueManager dm;
    private bool playerInRange;

    /// <summary>
    /// Caso seja uma cutscene, começa o dialogo
    /// </summary>
    public void Start()
    {
        if (dm.isCutscene == true)
        {
            TriggerDialogue();
        }
    }

    /// <summary>
    /// Funcao para comecar o diálogo
    /// </summary>
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    /// <summary>
    /// Quando apertar "Z" dentro da área e o player estiver dentro da área, comeca o diálogo
    /// </summary>
    public void Update()
    {
        if (Input.GetKeyDown(dm.key) && playerInRange == true && dm.isVNDialogue == true) // se estiver dentro do playerInRange e for um dialogo normal
        {
            Time.timeScale = 0f;
            if(dm.isDialogue == false) // Inicializa o diálogo, caso esse não esteja inicializado
                TriggerDialogue();
            else
                dm.DisplayNextSentence(); // Caso o diálogo esteja inicializado, vai para a próxima fala
        }
        
        if (playerInRange == true && dm.isCharacterDialogue == true) // se estiver dentro do playerInRange e for um characterdialogue
        {
            if(dm.isDialogue == false) // Inicializa o diálogo, caso esse não esteja inicializado
                TriggerDialogue();

        }

        if (Input.GetKeyDown(dm.key) && dm.isCutscene == true)
        {
            dm.DisplayNextSentence(); // Caso o diálogo esteja inicializado, vai para a próxima fala
                
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
            
            // Casi for um characterdialogue, ao sair do range do player, não mostra as falas
            if(dm.isCharacterDialogue == true)
                dm.EndDialogue();
        }
    }
}
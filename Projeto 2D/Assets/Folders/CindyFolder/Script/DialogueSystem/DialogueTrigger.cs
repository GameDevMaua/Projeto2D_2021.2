using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public DialogueManager dm;
    private bool playerInRange;
    public GameObject Dialogue;

    public void Start()
    {
        if (dm.isCutscene == true)
        {
            TriggerDialogue();
        }
    }

    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    /// <summary>
    /// Quando apertar "Z" dentro da área e o player estiver dentro da área, muda a cena para o local do nome da cena
    /// </summary>
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) && playerInRange == true && dm.isCutscene == false)
        {
            Time.timeScale = 0f;
            if(dm.isDialogue == false)
                TriggerDialogue();
            else
                dm.DisplayNextSentence();
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
        }
    }
}
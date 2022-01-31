using UnityEngine;

public class TriggerDialogue : MonoBehaviour
{
    public DialogueText[] Dialogues;
    public Character[] Characters;

    public void StartDialogue()
    {
        FindObjectOfType<ManagerDialogue>().OpenDialogue(Dialogues, Characters);
    }
    
    
}

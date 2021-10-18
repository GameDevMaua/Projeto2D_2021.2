using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainProject.Scripts.Dialogue
{
    public class DialogueTrigger : MonoBehaviour
    {
        public MainProject.Scripts.Dialogue.DialogueText[] Dialogues;
        public MainProject.Scripts.Dialogue.DialogueCharacter[] Characters;

        public void StartDialogue()
        {
            FindObjectOfType<MainProject.Scripts.Dialogue.DialogueManager>().OpenDialogue(Dialogues, Characters);
        }
    }
}
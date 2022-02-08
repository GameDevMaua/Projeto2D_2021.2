using System.Collections.Generic;
using UnityEngine;

namespace MainProject.Scripts.DialogueSystem.Abstract
{
    public abstract class AbstractDialogueManager : MonoBehaviour
    {
        public bool isDialogue = false;
        public Queue<MainProject.Scripts.DialogueSystem.Dialogue.Info> dInfos;
        public KeyCode key = KeyCode.E;

        public abstract void StartDialogue(MainProject.Scripts.DialogueSystem.Dialogue dialogue);
        public abstract void DisplayNextSentence();
        public abstract void EndDialogue();
    }
}
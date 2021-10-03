using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Classe abstrata do DialogueManager, pois existem 3 tipos
/// </summary>
public abstract class AbstractDialogueManager : MonoBehaviour
{

    public bool isDialogue = false;
    public Queue<Dialogue.Info> dInfos;
    public KeyCode key = KeyCode.Z;

    public abstract void StartDialogue(Dialogue dialogue);
    public abstract void DisplayNextSentence();
    public abstract void EndDialogue();
}


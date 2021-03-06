using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerDialogue : MonoBehaviour
{

    public Image characterSprite;
    public Text characterName;
    public Text dialogueText;
    public GameObject dialogueBox;

    DialogueText[] currentDialogue;
    Character[] currentCharacter;
    int activeDialogue = 0;
    public static bool isActive = false;


    public void OpenDialogue(DialogueText[] dialogue, Character[] character)
    {
        dialogueBox.SetActive(true);
        currentDialogue = dialogue;
        currentCharacter = character;
        activeDialogue = 0;
        isActive = true;
        DisplayDialogue();
    }

    public void DisplayDialogue()
    {
        DialogueText dialogueTextToDisplay = currentDialogue[activeDialogue];
        
        
        dialogueText.text = dialogueTextToDisplay.text;
        
        if (dialogueTextToDisplay.characterId >= currentCharacter.Length) return;
        
        Character characterToDisplay = currentCharacter[dialogueTextToDisplay.characterId];
        
        characterName.text = characterToDisplay.name;
        characterSprite.sprite = characterToDisplay.sprite;
    }


    public void NextDialogue()
    {
        activeDialogue++;

        if (activeDialogue < currentDialogue.Length)
        {
            DisplayDialogue();
        }
        else
        {
            Debug.Log("Conversation ended!");
            isActive = false;
            dialogueBox.SetActive(false);
        }

    }

    public void PressKeyToContinueDialogue()
    {
        if (Input.GetKeyDown(KeyCode.Z) && isActive == true)
        {
            NextDialogue();
        }
    }
    
    // Update is called once per frame
    void Update()
    {
       PressKeyToContinueDialogue();
    }
}

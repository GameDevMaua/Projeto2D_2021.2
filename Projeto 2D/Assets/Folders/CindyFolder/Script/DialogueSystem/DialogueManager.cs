using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Image characterSprite;
    public Text dialogueText;
    public GameObject gameObjectDialogue;
    public bool isCutscene = false;
    public SceneAsset newScene;
    public bool isDialogue = false;
    
    private Queue<String> sentences;

    private void Awake()
    {
        gameObjectDialogue.SetActive(false);
        sentences = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        isDialogue = true;
        gameObjectDialogue.SetActive(true);
        nameText.text = dialogue.dialogueInfo[0].characterprofile.Name;
        characterSprite.sprite = dialogue.dialogueInfo[0].characterprofile.Image;
        
        sentences.Clear();

        foreach (Dialogue.Info sentence in dialogue.dialogueInfo)
        {
            sentences.Enqueue(sentence.sentences);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(String sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
        
    }

    void EndDialogue()
    {
        gameObjectDialogue.SetActive(false);
        if (isCutscene == true)
        {
            SceneManager.LoadScene(newScene.name);
        }
        else
        {
            Time.timeScale = 1f;
            isDialogue = false;
        }
    }
    
}
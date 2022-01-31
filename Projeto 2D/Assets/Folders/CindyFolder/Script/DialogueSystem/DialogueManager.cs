using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// #if UNITY_EDITOR
// using UnityEditor;
// #endif

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Image characterSprite;
    public Text dialogueText;

    public Text[] characterdialogueText;
    public Text characterdialogueplayerText;

    public GameObject gameObjectVNDialogue;
    public GameObject[] gameObjectCharacterDialogue;
    public GameObject gameObjectPlayerDialogue;

    public bool isCutscene = false;
    public bool isVNDialogue = false;
    public bool isCharacterDialogue = false;
    
    // #if UNITY_EDITOR
    // public SceneAsset newScene;
    // #endif
    public string newScene;
    
    public bool isDialogue = false;
    public KeyCode key = KeyCode.Z;

    private Queue<Dialogue.Info> dInfos;

    /// <summary>
    /// Cria a Queue sentences e sempre começa sem o canvas do diálogo e do characterdialogue (caso não seja uma cutscene)
    /// </summary>
    private void Awake()
    {
        for (int i = 0; i < gameObjectCharacterDialogue.Length; i++)
        {
            gameObjectCharacterDialogue[i].SetActive(false);
        }

        gameObjectVNDialogue.SetActive(false);
       gameObjectPlayerDialogue.SetActive(false);
        dInfos = new Queue<Dialogue.Info>();
    }

    /// <summary>
    /// Início do diálogo
    /// </summary>
    /// <param name="dialogue"></param>
    public void StartDialogue(Dialogue dialogue)
    {
        isDialogue = true; /// O Sistema saber que o diálogo foi inicializado

        if (isVNDialogue == true || isCutscene == true)
            gameObjectVNDialogue.SetActive(true); /// Ativa o canvas do diálogo

        if (isCharacterDialogue == true)
            gameObjectPlayerDialogue.SetActive(true); /// Ativa o canvas do diálogo

        dInfos.Clear(); /// Limpa a Queue caso tenha algo dentro

        /// Para cada Dialogue.Info (Array com characterprofile e sentenca), coloca essa dentro da Queue
        foreach (Dialogue.Info info in dialogue.dialogueInfo)
        {
            dInfos.Enqueue(info);
        }

        DisplayNextSentence(); /// Vai para a próxima sentença
    }
    public void FunctionToDeactivateDialogue()
    {
        StartCoroutine(TimeToDisappearDialogue());
    }

    /// <summary>
    /// Próxima sentença
    /// </summary>
    public void DisplayNextSentence()
    {
        // Caso não tenha mais sentenças dentro da Queue, acaba o diálogo
        if (dInfos.Count == 0)
        {
            EndDialogue();
            return;
        }

        Dialogue.Info dInfo = dInfos.Dequeue(); // Tira o Dialogue.Info da Queue e coloca no nome, sprite e sentenca
        nameText.text = dInfo.characterprofile.Name; /// Referencia o nome do canvas ao nome do character profile
        characterSprite.sprite = dInfo.characterprofile.Image; /// Referencia o sprite do canvas ao sprite do character profile

        if (isCharacterDialogue == true)
        {
            for (int i = 0; i < characterdialogueText.Length; i++)
            {
                characterdialogueText[i].text = dInfo.sentences;
                characterdialogueplayerText.text = characterdialogueText[i].text;
            }
        }

        StopAllCoroutines(); // Para todas as corrotinas
        StartCoroutine(TypeSentence(dInfo.sentences)); // Começa a corrotina de TypeSentence
    }
    /// <summary>
    /// Para fazer com que apareça caracter por caracter no diálogo
    /// </summary>
    /// <param name="sentence"></param>
    /// <returns></returns>
    IEnumerator TypeSentence(String sentence)
    {
        dialogueText.text = ""; // Inicia com o texto vazio
        // Para cada caractér dentro da string "sentence", adiciona esse caracter dentro do texto do diálogo
        foreach (char letter in sentence.ToCharArray()) 
        {
            dialogueText.text += letter;
            yield return null;
        }
        
    }

    IEnumerator TimeToDisappearDialogue()
    {
        yield return new WaitForSeconds(2);

        if (GameObject.FindWithTag("DialogueBalloon"))
        {
            EndDialogue();
            Debug.Log("Desliguei");
        }
    }
    
    /// Fim do diálogo
    /// </summary>
    public void EndDialogue()
    {
        if (isVNDialogue == true)
            gameObjectVNDialogue.SetActive(false); // O canvas do Dialogo é desativado

        if (isCharacterDialogue == true)
        {
            for (int i = 0; i < gameObjectCharacterDialogue.Length; i++)
            {
                gameObjectCharacterDialogue[i].SetActive(false);
            }
            
            gameObjectPlayerDialogue.SetActive(false);
        }

        isDialogue = false;

        // Se for Cutscene, carrega uma nova cena após o termino do diálogo
        if (isCutscene == true)
        {
            #if UNITY_EDITOR
            SceneManager.LoadScene(newScene);
            #endif
        }
        else // Se não, volta para o jogo
        {
            Time.timeScale = 1f;
            isDialogue = false;
        }
        

    }
}
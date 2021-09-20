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
    public KeyCode key = KeyCode.Z;
    
    private Queue<Dialogue.Info> dInfos;

    /// <summary>
    /// Cria a Queue sentences e sempre começa sem o canvas do diálogo (caso não seja uma cutscene)
    /// </summary>
    private void Awake()
    {
        gameObjectDialogue.SetActive(false);
        dInfos = new Queue<Dialogue.Info>();
    }

    /// <summary>
    /// Início do diálogo
    /// </summary>
    /// <param name="dialogue"></param>
    public void StartDialogue(Dialogue dialogue)
    {
        isDialogue = true; /// O Sistema saber que o diálogo foi inicializado
        gameObjectDialogue.SetActive(true); /// Ativa o canvas do diálogo

        dInfos.Clear(); /// Limpa a Queue caso tenha algo dentro

        /// Para cada Dialogue.Info (Array com characterprofile e sentenca), coloca essa dentro da Queue
        foreach (Dialogue.Info info in dialogue.dialogueInfo)
        {
            dInfos.Enqueue(info);
        }

        DisplayNextSentence(); /// Vai para a próxima sentença
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

    /// <summary>
    /// Fim do diálogo
    /// </summary>
    void EndDialogue()
    {
        gameObjectDialogue.SetActive(false); // O canvas do Dialogo é desativado
        
        // Se for Cutscene, carrega uma nova cena após o termino do diálogo
        if (isCutscene == true)
        {
            SceneManager.LoadScene(newScene.name);
        }
        else // Se não, volta para o jogo
        {
            Time.timeScale = 1f;
            isDialogue = false;
        }
    }
    
}
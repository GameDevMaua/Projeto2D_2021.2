#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using UnityEditor;

/// <summary>
/// Quando a cena só tem diálogo e sem jogatina
/// </summary>
public class CutsceneDialogueManager : AbstractDialogueManager
{
    public Dialogue dialogue;
    
    public Text cutsceneNameText;
    public Image cutsceneCharacterSprite;
    public Text cutsceneDialogueText;

    public GameObject gameObjectCutsceneDialogue;

    public SceneAsset newScene;

    /// <summary>
    /// Cria a Queue sentences, inicia o dialogo e ativa o gameobject do dialogo
    /// </summary>
    /// 
    private void Awake()
    {
        gameObjectCutsceneDialogue.SetActive(true);
        dInfos = new Queue<Dialogue.Info>();
        StartDialogue(dialogue);
    }

    public void Update()
    {
        if (Input.GetKeyDown(key)) // Caso aperte o botao, vai para a proxima sentenca
        {
            DisplayNextSentence(); 
                
        }
    }

    /// <summary>
    /// Início do diálogo
    /// </summary>
    /// <param name="dialogue"></param>
    public override void StartDialogue(Dialogue dialogue)
    {
        isDialogue = true; /// O Sistema sabe que o diálogo foi inicializado
        
        gameObjectCutsceneDialogue.SetActive(true); /// Ativa o canvas do diálogo

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
    public override void DisplayNextSentence()
    {
        // Caso não tenha mais sentenças dentro da Queue, acaba o diálogo
        if (dInfos.Count == 0)
        {
            EndDialogue();
            return;
        }

        Dialogue.Info dInfo = dInfos.Dequeue(); // Tira o Dialogue.Info da Queue e coloca no nome, sprite e sentenca
        cutsceneNameText.text = dInfo.characterprofile.Name; /// Referencia o nome do canvas ao nome do character profile
        cutsceneCharacterSprite.sprite = dInfo.characterprofile.Image; /// Referencia o sprite do canvas ao sprite do character profile}

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
        cutsceneDialogueText.text = ""; // Inicia com o texto vazio
        // Para cada caractér dentro da string "sentence", adiciona esse caracter dentro do texto do diálogo
        foreach (char letter in sentence.ToCharArray())
        {
            cutsceneDialogueText.text += letter;
            yield return null;
        }

    }

    /// <summary>
    /// Fim do diálogo
    /// </summary>
    public override void EndDialogue()
    {
        gameObjectCutsceneDialogue.SetActive(false); // O canvas do Dialogo é desativado
        

        isDialogue = false;
        SceneManager.LoadScene(newScene.name); // Vai para a proxima cena

    }
}
#endif
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Esse dialoguemanager serve quando o player se aproxima do gameobject e aparece o dialogo
/// </summary>
public class CharacterDialogueManager: AbstractDialogueManager
{
       public GameObject[] gameObjectCharacterDialogue;
       public GameObject gameObjectplayerDialogue;
       public Text [] characterDialogueText;
       public Text playerDialogueText;
       
       /// <summary>
       /// Quando começar, deixar todos os diálogos inativados e criar um Queue
       /// </summary>
       private void Awake()
       {
              for (int i = 0; i < gameObjectCharacterDialogue.Length; i++)
              {
                     gameObjectCharacterDialogue[i].SetActive(false);
              }
              gameObjectplayerDialogue.SetActive(false);
              dInfos = new Queue<Dialogue.Info>();
       }
       
       /// <summary>
       ///Inicio do dialogo
       /// </summary>
       /// <param name="dialogue"></param>
       public override void StartDialogue(Dialogue dialogue)
       {
              isDialogue = true;
              gameObjectplayerDialogue.SetActive(true); /// Ativa o canvas do diálogo

              dInfos.Clear(); /// Limpa a Queue caso tenha algo dentro

              /// Para cada Dialogue.Info (Array com characterprofile e sentenca), coloca essa dentro da Queue
              foreach (Dialogue.Info info in dialogue.dialogueInfo)
              {
                     dInfos.Enqueue(info);
              }

              DisplayNextSentence(); /// Vai para a próxima sentença
       }
       
       /// <summary>
       /// próximo dialogo
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

              // Para todos os characterdialogue, atribuir o texto para as sentences presente na Queue e atribuir essas sentences no characterdialogue do player
              for (int i = 0; i < characterDialogueText.Length; i++) 
              {
                            characterDialogueText[i].text = dInfo.sentences;
                            playerDialogueText.text = characterDialogueText[i].text; 
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
    
       public void FunctionToDeactivateDialogue()
       {
              StartCoroutine(TimeToDisappearDialogue());
       }
       
       /// <summary>
       /// Fim do dialogo
       /// </summary>
       public override void EndDialogue()
       {
             // Para cada characterdialogue atribuido para um personagem, desativá-lo
              for (int i = 0; i < gameObjectCharacterDialogue.Length; i++) 
              {
                            gameObjectCharacterDialogue[i].SetActive(false); 
              }
              
              gameObjectplayerDialogue.SetActive(false); //Desativar o characterdialogue do player

              isDialogue = false; 
                     
       }
}


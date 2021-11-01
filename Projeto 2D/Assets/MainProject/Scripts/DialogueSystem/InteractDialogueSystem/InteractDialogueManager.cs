using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MainProject.Scripts.DialogueSystem.InteractDialogueSystem
{
    public class InteractDialogueManager : Abstract.AbstractDialogueManager
    {
        public Text nameText;
        public Image characterSprite;
        public Text dialogueText;

        public GameObject gameObjectInteractDialogue;

        /// <summary>
        /// Cria a Queue sentences e sempre começa sem o canvas do diálogo e do characterdialogue (caso não seja uma cutscene)
        /// </summary>
        private void Awake()
        {
            gameObjectInteractDialogue.SetActive(false);
            dInfos = new Queue<MainProject.Scripts.DialogueSystem.Dialogue.Info>();
        }

        /// <summary>
        /// Início do diálogo
        /// </summary>
        /// <param name="dialogue"></param>
        public override void StartDialogue(MainProject.Scripts.DialogueSystem.Dialogue dialogue)
        {
            isDialogue = true; /// O Sistema saber que o diálogo foi inicializado
            
            gameObjectInteractDialogue.SetActive(true); /// Ativa o canvas do diálogo

            dInfos.Clear(); /// Limpa a Queue caso tenha algo dentro

            /// Para cada Dialogue.Info (Array com characterprofile e sentenca), coloca essa dentro da Queue
            foreach (var info in dialogue.dialogueInfo)
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

            var dInfo = dInfos.Dequeue(); // Tira o Dialogue.Info da Queue e coloca no nome, sprite e sentenca
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
            foreach (var letter in sentence.ToCharArray())
            {
                dialogueText.text += letter;
                yield return null;
            }

        }


        /// <summary>
        /// Fim do diálogo
        /// </summary>
        public override void EndDialogue()
        {
            gameObjectInteractDialogue.SetActive(false); // O canvas do Dialogo é desativado
            isDialogue = false;
            Time.timeScale = 1f;

        }
    }
}
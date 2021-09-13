using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainProject.Abstract
{
    public abstract class ObjectAnimation : MonoBehaviour
    {
        [SerializeField]
        private string animation; // Nome ou path da animação que será exibida neste objeto
        protected Animator animator; // Instância do objeto Animator
        private bool attachedAnimationString; // true se existir algum valor atribuído ao atributo animation
    
        /// <summary>
        /// Chamada do Awake para a classe ObjectAnimation, incializa variáveis com valores padrões
        /// </summary>
        protected void AwakeObjectAnimation()
        {
            animator = GetComponent<Animator>();
            attachedAnimationString = VerifyStringStatus(animation);
            PlayObjectAnimation();
        }

        /// <summary>
        /// Executa a animação atribuída ao objeto
        /// </summary>
        private void PlayObjectAnimation()
        {
            if (attachedAnimationString) animator.Play(animation);
        }

        /// <summary>
        /// Verifica se existe algum valor atribuído à string
        /// </summary>
        /// <param name="verify">string a ser verificada</param>
        /// <returns>true caso a string tenha algum valor, false caso a string esteja vazia or null</returns>
        private static bool VerifyStringStatus(string verify)
        {
            if (verify is null) return false;
            return verify.Length != 0;
        }
    }
}


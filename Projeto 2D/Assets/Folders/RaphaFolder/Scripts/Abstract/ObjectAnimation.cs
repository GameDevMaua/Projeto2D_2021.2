using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (!attachedAnimationString) return;
        if (VerifyAnimationInAnimator(animation, animator)) animator.Play(animation);
        else Debug.Log("ERRO: A animação desejada não foi encontrada no controlador do objeto: " + gameObject);
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

    /// <summary>
    /// Verifica se a animação está presente no animator do objeto
    /// </summary>
    /// <param name="animation">Nome da animação desejada</param>
    /// <param name="animator">Referência do Animator a executar a animação desejada</param>
    /// <returns>True - caso o Animator seja capaz de executar a animação, False - caso contrário</returns>
    private static bool VerifyAnimationInAnimator(string animation, Animator animator)
    {
        var animationsInController = animator.runtimeAnimatorController.animationClips;
        return animationsInController.Any(an => an.name.Equals(animation));
    }
}

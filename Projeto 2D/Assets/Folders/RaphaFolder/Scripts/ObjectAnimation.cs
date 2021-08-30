using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class ObjectAnimation : MonoBehaviour
{
    [SerializeField]
    private string animation;
    protected Animator animator;
    protected bool attachedAnimationString;
    
    /// <summary>
    /// Awake call for the ObjectAnimation class, start variables with standard values
    /// </summary>
    protected void AwakeObjectAnimation()
    {
        animator = GetComponent<Animator>();
        attachedAnimationString = VerifyStringStatus(animation);
        PlayObjectAnimation();
    }

    /// <summary>
    /// Executes the designed animation to the object
    /// </summary>
    private void PlayObjectAnimation()
    {
        if (attachedAnimationString) animator.Play(animation);
    }

    /// <summary>
    /// Verify if the string has some value
    /// </summary>
    /// <param name="verify">string to be verified</param>
    /// <returns>true case the string has some value, false case the string is empty or null</returns>
    private static bool VerifyStringStatus(string verify)
    {
        if (verify is null) return false;
        return verify.Length != 0;
    }

}

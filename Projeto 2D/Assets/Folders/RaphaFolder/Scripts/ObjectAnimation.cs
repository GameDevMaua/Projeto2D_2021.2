using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectAnimation
{
    public String animationName;
    private Animator animator;

    public void PlayObjectAnimation()
    {
        animator.Play(animationName);
    }
    
}

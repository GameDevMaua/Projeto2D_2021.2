using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public abstract class PlayerAnimation : MonoBehaviour
{
    [Header("Animation Packs (Insert archive name - alphabetic order):")]
    public List<string> electroAnimationPack;
    public List<string> geoAnimationPack;
    public List<string> hydroAnimationPack;
    public List<string> noneAnimationPack;
    public List<string> pyroAnimationPack;
    
    // Private variables
    private List<string> currentAnimationPack;
    private Animator animator;
    
    [Header("Initial test param")]
    public Direction playerDirection;
    public Element.ElementType playerCurrentElement;

    protected void AnimationAwake()
    {
        // Getting references
        animator = GetComponent<Animator>();

        // Setting the animation packs
        if (electroAnimationPack.Count == 0)
            electroAnimationPack = new List<string>{ };
        if (geoAnimationPack.Count == 0)
            geoAnimationPack = new List<string>{ };
        if (hydroAnimationPack.Count == 0)
            hydroAnimationPack = new List<string>{ };
        if (noneAnimationPack.Count == 0)
            noneAnimationPack = new List<string>{
                "Down_Animation",
                "DownIdle_Animation",
                "Left_Animation",
                "LeftIdle_Animation",
                "NONE_Animation",
                "Right_Animation",
                "RightIdle_Animation",
                "Up_Animation",
                "UpIdle_Animation"
            };
        if (pyroAnimationPack.Count == 0)
            pyroAnimationPack = new List<string>{ };

        // Starting the first animation pack
        currentAnimationPack = noneAnimationPack;
    }

    // Update is called once per frame
    protected void AnimationUpdate()
    {
        UpdateAttributes();
        UpdateAnimationPack();
        PlayAnimation();
    }

    private void UpdateAttributes()
    {
        // Update:
        
        //playerDirection =
        //playerCurrentElement = 
    }

    private void UpdateAnimationPack()
    {
        switch (playerCurrentElement)
        {
            case Element.ElementType.ELECTRO:
                if (electroAnimationPack.Count != 0)
                    currentAnimationPack = electroAnimationPack;
                break;
            case Element.ElementType.GEO:
                if (geoAnimationPack.Count != 0)
                    currentAnimationPack = geoAnimationPack;
                break;
            case Element.ElementType.HYDRO:
                if (hydroAnimationPack.Count != 0)
                    currentAnimationPack = hydroAnimationPack;
                break;
            case Element.ElementType.NONE:
                if (noneAnimationPack.Count != 0)
                    currentAnimationPack = noneAnimationPack;
                break;
            case Element.ElementType.PYRO:
                if (pyroAnimationPack.Count != 0)
                    currentAnimationPack = pyroAnimationPack;
                break;
        }
    }

    private void PlayAnimation()
    {
        switch (playerDirection)
        {
            case Direction.DOWN:
                animator.Play(currentAnimationPack[0]);
                break;
            case Direction.DOWN_IDLE:
                animator.Play(currentAnimationPack[1]);
                break;
            case Direction.LEFT:
                animator.Play(currentAnimationPack[2]);
                break;
            case Direction.LEFT_IDLE:
                animator.Play(currentAnimationPack[3]);
                break;
            case Direction.NONE:
                animator.Play(currentAnimationPack[4]);
                break;
            case Direction.RIGHT:
                animator.Play(currentAnimationPack[5]);
                break;
            case Direction.RIGHT_IDLE:
                animator.Play(currentAnimationPack[6]);
                break;
            case Direction.UP:
                animator.Play(currentAnimationPack[7]);
                break;
            case Direction.UP_IDLE:
                animator.Play(currentAnimationPack[8]);
                break;
            default:
                animator.Play(currentAnimationPack[4]);
                break;
        }
    }
}

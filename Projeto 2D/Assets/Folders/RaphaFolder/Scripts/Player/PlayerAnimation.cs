using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public abstract class PlayerAnimation : ObjectAnimation
{
    [Header("Animation Packs (Insert archive name - alphabetic order):")]
    // Animation packs to fit the player's current element animations with the same system
    public List<string> electroAnimationPack;
    public List<string> geoAnimationPack;
    public List<string> hydroAnimationPack;
    public List<string> noneAnimationPack;
    public List<string> pyroAnimationPack;
    
    // Private attributes
    private List<string> currentAnimationPack; // Actual animation pack selected
    private PlayerStatus playerStatus; // Holds the instance of it's status
    private Direction playerDirection; // The direction the player is facing (test param, will change with other class)
    private Element.ElementType playerCurrentElement; // The current element of the player (test param, will change with other class)

    /// <summary>
    /// Awake call for the PlayerAnimation class, start variables with standard values
    /// </summary>
    protected void AnimationAwake()
    {
        // Calls the awake statement of it's father's class
        AwakeObjectAnimation();
        
        // Try get PlayerStatus class instance
        playerStatus = GetComponent<PlayerStatus>();
        
        // Setting standard the animation packs
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

    /// <summary>
    /// Update call for the PlayerAnimation class, executes the PlayerAnimation's function
    /// </summary>
    protected void AnimationUpdate()
    {
        UpdateAttributes();
        UpdateAnimationPack();
        PlayAnimation();
    }

    /// <summary>
    /// Update playerDirection and currentElement attributes
    /// </summary>
    private void UpdateAttributes()
    {
        if (!(playerStatus is null))
        {
            playerDirection = playerStatus.getPlayerDirection();
            playerCurrentElement = playerStatus.getObjectElement();
        }
        else Debug.Log("PlayerStatus instance not found on player object");
    }

    /// <summary>
    /// Update the selected animation pack according to the player current element
    /// </summary>
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

    /// <summary>
    /// Plays the animation according to the direction the player is on
    /// </summary>
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

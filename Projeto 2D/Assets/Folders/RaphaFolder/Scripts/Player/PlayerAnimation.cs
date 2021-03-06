using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public abstract class PlayerAnimation : ObjectAnimation
{
    [Header("Animation Packs (Insert archive name - alphabetic order):")]
    // Packs de animações para alterarem os sprites do elemento atual do player com o mesmo sistema
    public List<string> electroAnimationPack;
    public List<string> geoAnimationPack;
    public List<string> hydroAnimationPack;
    public List<string> noneAnimationPack;
    public List<string> pyroAnimationPack;
    
    // Atributos privados
    private List<string> currentAnimationPack; // Animation pack selecionado atualmente
    private PlayerStatus playerStatus; // Instancia do status do jogador
    private Direction playerDirection; // A direção para a qual o player está voltado
    private Element.ElementType playerCurrentElement; // O tipo elemental atual do jogador

    /// <summary>
    /// Chamada do Awake para a classe PlayerAnimation, incializa variáveis com valores padrões
    /// </summary>
    protected void AnimationAwake()
    {
        // Inicializa os parâmetros da classe pai
        AwakeObjectAnimation();
        
        // Tenta instanciar a classe PlayerStatus
        playerStatus = GetComponent<PlayerStatus>();
        
        // Define animation packs padrões
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

        // Inicializa o primeiro animation pack
        currentAnimationPack = noneAnimationPack;
    }

    /// <summary>
    /// Chamada do Update para a classe PlayerAnimation, executa as funções principais da classe
    /// </summary>
    protected void AnimationUpdate()
    {
        UpdateAttributes();
        UpdateAnimationPack();
        PlayAnimation();
    }

    /// <summary>
    /// Atualiza a direção do player e seu tipo elemental
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
    /// Atualiza a animation pack selecionada de acordo com o tipo elemental atual do jogador
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
    /// Toca as animações do animation pack de acordo com a direção para a qual o player está voltado
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

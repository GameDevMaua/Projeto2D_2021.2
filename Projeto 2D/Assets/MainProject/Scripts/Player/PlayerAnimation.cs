using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace MainProject.Scripts.Player
{
    public class PlayerAnimation : MainProject.Abstract.ObjectAnimation
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
        private MainProject.Scripts.Player.PlayerStatus playerStatus; // Instancia do status do jogador
        private MainProject.Enums.Direction playerDirection; // A direção para a qual o player está voltado
        private MainProject.Enums.Element playerCurrentElement; // O tipo elemental atual do jogador

        /// <summary>
        /// Chamada do Awake para a classe PlayerAnimation, incializa variáveis com valores padrões
        /// </summary>
        protected void Awake()
        {
            // Inicializa os parâmetros da classe pai
            AwakeObjectAnimation();

            // Tenta instanciar a classe PlayerStatus
            playerStatus = GetComponent<MainProject.Scripts.Player.PlayerStatus>();

            // Define animation packs padrões
            if (electroAnimationPack.Count == 0)
                electroAnimationPack = new List<string>
                {
                    "Down_Animation_ELECTRO_ELEMENT",
                    "DownIdle_Animation_ELECTRO_ELEMENT",
                    "Left_Animation_ELECTRO_ELEMENT",
                    "LeftIdle_Animation_ELECTRO_ELEMENT",
                    "NONE_Animation_ELECTRO_ELEMENT",
                    "Right_Animation_ELECTRO_ELEMENT",
                    "RightIdle_Animation_ELECTRO_ELEMENT",
                    "Up_Animation_ELECTRO_ELEMENT",
                    "UpIdle_Animation_ELECTRO_ELEMENT"
                };
            if (geoAnimationPack.Count == 0)
                geoAnimationPack = new List<string>
                {
                    "Down_Animation_GEO_ELEMENT",
                    "DownIdle_Animation_GEO_ELEMENT",
                    "Left_Animation_GEO_ELEMENT",
                    "LeftIdle_Animation_GEO_ELEMENT",
                    "NONE_Animation_GEO_ELEMENT",
                    "Right_Animation_GEO_ELEMENT",
                    "RightIdle_Animation_GEO_ELEMENT",
                    "Up_Animation_GEO_ELEMENT",
                    "UpIdle_Animation_GEO_ELEMENT"
                };
            if (hydroAnimationPack.Count == 0)
                hydroAnimationPack = new List<string>
                {
                    "Down_Animation_HYDRO_ELEMENT",
                    "DownIdle_Animation_HYDRO_ELEMENT",
                    "Left_Animation_HYDRO_ELEMENT",
                    "LeftIdle_Animation_HYDRO_ELEMENT",
                    "NONE_Animation_HYDRO_ELEMENT",
                    "Right_Animation_HYDRO_ELEMENT",
                    "RightIdle_Animation_HYDRO_ELEMENT",
                    "Up_Animation_HYDRO_ELEMENT",
                    "UpIdle_Animation_HYDRO_ELEMENT"
                };
            if (noneAnimationPack.Count == 0)
                noneAnimationPack = new List<string>
                {
                    "Down_Animation_NONE_ELEMENT",
                    "DownIdle_Animation_NONE_ELEMENT",
                    "Left_Animation_NONE_ELEMENT",
                    "LeftIdle_Animation_NONE_ELEMENT",
                    "NONE_Animation_NONE_ELEMENT",
                    "Right_Animation_NONE_ELEMENT",
                    "RightIdle_Animation_NONE_ELEMENT",
                    "Up_Animation_NONE_ELEMENT",
                    "UpIdle_Animation_NONE_ELEMENT"
                };
            if (pyroAnimationPack.Count == 0)
                pyroAnimationPack = new List<string>
                {
                    "Down_Animation_PYRO_ELEMENT",
                    "DownIdle_Animation_PYRO_ELEMENT",
                    "Left_Animation_PYRO_ELEMENT",
                    "LeftIdle_Animation_PYRO_ELEMENT",
                    "NONE_Animation_PYRO_ELEMENT",
                    "Right_Animation_PYRO_ELEMENT",
                    "RightIdle_Animation_PYRO_ELEMENT",
                    "Up_Animation_PYRO_ELEMENT",
                    "UpIdle_Animation_PYRO_ELEMENT"
                };

            // Inicializa o primeiro animation pack
            currentAnimationPack = noneAnimationPack;
        }

        /// <summary>
        /// Chamada do Update para a classe PlayerAnimation, executa as funções principais da classe
        /// </summary>
        protected void Update()
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
                case MainProject.Enums.Element.ELECTRO:
                    if (electroAnimationPack.Count != 0)
                        currentAnimationPack = electroAnimationPack;
                    break;
                case MainProject.Enums.Element.GEO:
                    if (geoAnimationPack.Count != 0)
                        currentAnimationPack = geoAnimationPack;
                    break;
                case MainProject.Enums.Element.HYDRO:
                    if (hydroAnimationPack.Count != 0)
                        currentAnimationPack = hydroAnimationPack;
                    break;
                case MainProject.Enums.Element.NONE:
                    if (noneAnimationPack.Count != 0)
                        currentAnimationPack = noneAnimationPack;
                    break;
                case MainProject.Enums.Element.PYRO:
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
                case MainProject.Enums.Direction.DOWN:
                    animator.Play(currentAnimationPack[0]);
                    break;
                case MainProject.Enums.Direction.DOWN_IDLE:
                    animator.Play(currentAnimationPack[1]);
                    break;
                case MainProject.Enums.Direction.LEFT:
                    animator.Play(currentAnimationPack[2]);
                    break;
                case MainProject.Enums.Direction.LEFT_IDLE:
                    animator.Play(currentAnimationPack[3]);
                    break;
                case MainProject.Enums.Direction.NONE:
                    animator.Play(currentAnimationPack[4]);
                    break;
                case MainProject.Enums.Direction.RIGHT:
                    animator.Play(currentAnimationPack[5]);
                    break;
                case MainProject.Enums.Direction.RIGHT_IDLE:
                    animator.Play(currentAnimationPack[6]);
                    break;
                case MainProject.Enums.Direction.UP:
                    animator.Play(currentAnimationPack[7]);
                    break;
                case MainProject.Enums.Direction.UP_IDLE:
                    animator.Play(currentAnimationPack[8]);
                    break;
                default:
                    animator.Play(currentAnimationPack[4]);
                    break;
            }
        }
    }
}

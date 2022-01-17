using System.Collections.Generic;
using UnityEngine;


namespace MainProject.Scripts
{
    public class SwitchScript : MonoBehaviour
    {
        public enum KeyPosition
        {
            FRENTE, DIREITA, ESQUERDA
        }
        
        public List<GameObject> objectsPrimarySelection;
        public List<GameObject> objectsSecondarySelection;
        public KeyCode interactionKey;
        public KeyPosition keyPositionForSprite;
        [SerializeField]
        private double interactionDistance = 5f;
        [Header("Padrão dos sprites abaixo: Frente, Esquerda, Direita")]
        [SerializeField] private List<Sprite> switchSprites; // Frente (1/0), Esquerda (1/0), Direita (1/0)
        
        private bool switchSpriteState;
        private bool switchBool;
        private GameObject playerRef;
        private SpriteRenderer spriteRendererRef;

        /// <summary>
        /// Chamada Awake da alavanca
        /// </summary>
        private void Awake()
        {
            playerRef = GameObject.FindWithTag("Player");
            spriteRendererRef = gameObject.GetComponent<SpriteRenderer>();
            switchBool = true;
            switchSpriteState = true;

            if (objectsPrimarySelection.Count == 0 && objectsSecondarySelection.Count == 0) Debug.Log("Nenhum objeto atribuído à switch: " + gameObject);
            else
            {
                if (objectsPrimarySelection.Count != 0)
                {
                    foreach (var VARIABLE in objectsPrimarySelection) VARIABLE.SetActive(switchBool); // Ativa todos os objetos
                }

                if (objectsSecondarySelection.Count != 0)
                    foreach (var VARIABLE in objectsSecondarySelection) VARIABLE.SetActive(!switchBool); // Desativa todos os objetos
            }
            if (interactionKey.Equals(KeyCode.None)) interactionKey = KeyCode.E;
            CheckSwitchSprite();
        }

        private void Update()
        {
            InteractionVerify();
        }

        /// <summary>
        /// Retorna se o player está na distância correta de interação com a alavanca
        /// </summary>
        /// <returns>true - caso seja possível interagir </returns>
        private bool IsThisObjectInInteractionRange()
        {
            return !((playerRef.transform.position - gameObject.transform.position).magnitude > interactionDistance);
        }

        /// <summary>
        /// Altera os objetos ativos na cena.
        /// </summary>
        private void SwitchActiveObjects()
        {
                switchBool = !switchBool;
                switchSpriteState = !switchSpriteState;
                foreach (var VARIABLE in objectsPrimarySelection) VARIABLE.SetActive(switchBool);
                foreach (var VARIABLE in objectsSecondarySelection) VARIABLE.SetActive(!switchBool);
        }

        /// <summary>
        /// Verifica se houve interação com a alavanca
        /// </summary>
        private void InteractionVerify()
        {
            if (!Input.GetKeyUp(interactionKey) || !IsThisObjectInInteractionRange()) return;
            SwitchActiveObjects();
            CheckSwitchSprite();
        }

        private void CheckSwitchSprite()
        {
            spriteRendererRef.sprite = keyPositionForSprite switch
            {
                KeyPosition.FRENTE => switchSpriteState ? switchSprites[0] : switchSprites[1],
                KeyPosition.ESQUERDA => switchSpriteState ? switchSprites[2] : switchSprites[3],
                KeyPosition.DIREITA => switchSpriteState ? switchSprites[4] : switchSprites[5],
                _ => spriteRendererRef.sprite
            };
        }
    }
}

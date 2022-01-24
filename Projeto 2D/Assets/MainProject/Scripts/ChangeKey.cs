using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MainProject.Scripts
{
    public class ChangeKey : MonoBehaviour
    {
        public MainProject.Scripts.BindKey bindKey;

        /// <summary>
        /// Caso o i da classe BindKey for maior que i, ele desativa a imagem e executa a corotina
        /// </summary>
        private void Update()
        {
            if (bindKey.i >= 1)
            {
                bindKey.changeKeyBind.changeKeyImage.SetActive(false);

            }
        }
    }
}
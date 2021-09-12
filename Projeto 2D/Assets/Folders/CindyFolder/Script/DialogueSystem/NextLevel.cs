using System;
using UnityEngine;
using UnityEngine.SceneManagement;
        
        public class NextLevel : MonoBehaviour
        {
            public String levelName;
            public bool playerInRange;

            /// <summary>
            /// Quando apertar "Z" dentro da área e o player estiver dentro da área, muda a cena para o local do nome da cena
            /// </summary>
            public void Update()
            {
                if (Input.GetKeyDown(KeyCode.Z) && playerInRange == true)
                {
                    SceneManager.LoadScene(levelName);
                }
            }
        
            /// <summary>
            /// Quando o player estiver dentro da área, aumenta o Gameobject da cena para saber que o player pode apertar "Z"
            /// </summary>
            /// <param name="other"></param>
            private void OnTriggerEnter2D(Collider2D other)
            {
                if (other.attachedRigidbody)
                {
                    this.gameObject.transform.localScale = new Vector3(2, 2, 2);
                    playerInRange = true;
                }

            }

            /// <summary>
            /// Quando o player estiver fora da área, diminui o Gameobject da cena para saber que o player não consegue apertar "Z"
            /// </summary>
            /// <param name="other"></param>
            private void OnTriggerExit2D(Collider2D other)
            {
                if (other.attachedRigidbody)
                {
                    this.gameObject.transform.localScale = new Vector3(1, 1, 1);
                    playerInRange = false;
                }
            }
        }



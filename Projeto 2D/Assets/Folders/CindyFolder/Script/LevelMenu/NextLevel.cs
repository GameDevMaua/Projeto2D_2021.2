using System;
using UnityEngine;
using UnityEngine.SceneManagement;
        
        public class NextLevel : MonoBehaviour
        {
            public String levelName;
            private bool playerInRange;

            public void Update()
            {
                if (Input.GetKeyDown(KeyCode.Z) && playerInRange == true)
                {
                    SceneManager.LoadScene(levelName);
                }
            }
        
            private void OnTriggerEnter2D(Collider2D other)
            {
                if (other.attachedRigidbody)
                {
                    this.gameObject.transform.localScale = new Vector3(2, 2, 2);
                    playerInRange = true;
                }
                else
                {
                    this.gameObject.transform.localScale = new Vector3(1, 1, 1);
                    playerInRange = false;
                }
            }
        }

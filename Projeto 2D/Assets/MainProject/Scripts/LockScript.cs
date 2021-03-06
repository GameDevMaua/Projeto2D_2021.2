using System.Collections.Generic;
using System.Linq;
using FMODUnity;
using UnityEngine;

namespace MainProject.Scripts
{
    public class LockScript : MonoBehaviour
    {
        public List<GameObject> keys;
        public string sfxPathOpening;
        public string sfxPathLocked;
        
        [Header("Se abrir a porta passa o level ou não, por padrão sim")]
        public bool nextLevelOnOpen;
        
        private bool isOpened;
        private GameObject playerRef;
        public int i;
        private MainProject.Scripts.GameManager gameManager;
        
        private void Awake()
        {
            if (keys.Count == 0) Debug.Log("Atenção, nenhuma chave atribuída à fechadura: " + gameObject);
            playerRef = GameObject.FindWithTag("Player");
            gameManager = GameObject.FindWithTag("GameManager").GetComponent<MainProject.Scripts.GameManager>();
            isOpened = false;
        }

        private void OnEnable()
        {
            if (isOpened) gameObject.SetActive(false);
        }
    
        // Update is called once per frame
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!other.gameObject.Equals(playerRef)) return;
            if (keys.Any(VARIABLE => VARIABLE.GetComponent<MainProject.Scripts.KeyScript>().isCollected == false))
            {
                RuntimeManager.CreateInstance(sfxPathLocked).start();
                return;
            }
            isOpened = true;
            RuntimeManager.CreateInstance(sfxPathOpening).start();
            gameObject.SetActive(false);
            if (nextLevelOnOpen)
            {
                gameManager.LoadNextLevel();
            }
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MainProject.Scripts
{
    public class LockScript : MonoBehaviour
    {
        public List<GameObject> keys;
    
        private bool isOpened;
        private GameObject playerRef;
    
        private void Awake()
        {
            if (keys.Count == 0) Debug.Log("Atenção, nenhuma chave atribuída à fechadura: " + gameObject);
            playerRef = GameObject.FindWithTag("Player");
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
            if (keys.Any(VARIABLE => VARIABLE.GetComponent<MainProject.Scripts.KeyScript>().isCollected == false)) return;
            isOpened = true;
            gameObject.SetActive(false);
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

namespace MainProject.Scripts
{
    public class KeyScript : MonoBehaviour
    {
        public GameObject locker;
        public bool isCollected;

        private GameObject playerRef;

        private void Awake()
        {
            if (locker.Equals(null)) Debug.Log("Atenção, nenhuma fechadura atribuída à chave: " + gameObject);
            isCollected = false;
            playerRef = GameObject.FindWithTag("Player");
        }

        private void OnEnable()
        {
            if (isCollected) gameObject.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.gameObject.Equals(playerRef)) return;
            isCollected = true;
            gameObject.SetActive(false);
        }
    }
}
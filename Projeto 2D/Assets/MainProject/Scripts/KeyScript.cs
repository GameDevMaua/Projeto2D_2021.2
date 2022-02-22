using FMOD.Studio;
using FMODUnity;
using UnityEngine;

namespace MainProject.Scripts
{
    public class KeyScript : MonoBehaviour
    {
        public GameObject locker;
        public bool isCollected;
        public string sfxPath;
        
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
            RuntimeManager.CreateInstance(sfxPath).start();
            if (!other.gameObject.Equals(playerRef)) return;
            isCollected = true;
            gameObject.SetActive(false);
        }
    }
}
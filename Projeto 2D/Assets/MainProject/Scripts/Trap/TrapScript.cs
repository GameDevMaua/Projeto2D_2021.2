using System;
using System.Collections;
using System.Collections.Generic;
using Folders.HaFolder;
using UnityEngine;
using Random = System.Random;

namespace MainProject.Scripts.Trap
{
    public class TrapScript : MonoBehaviour
    {
        public string sfxPathSuccess;
        public string sfxPathFail;

        /// <summary>
        /// Caso um GameObject que tenha o PlayerStatus passar pela trap, verifica-se se o elemento do PlayerStatus é o 
        /// mesmo desse objeto. Se sim, nada acontece e player passará. Se nao, o PlayerStatus será atualizado para morte
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter2D(Collider2D other)
        {
            var playerStatus = other.GetComponent<MainProject.Scripts.Player.PlayerStatus>();
            var objectElement = gameObject.GetComponent<MainProject.Scripts.Trap.TrapStatus>().getObjectElement();
            if (!playerStatus) return;
            if (playerStatus.getObjectElement() != objectElement)
            {
                playerStatus.setPlayerDead();
                FMODUnity.RuntimeManager.CreateInstance(sfxPathFail).start();
            }
            else{
                FMODUnity.RuntimeManager.CreateInstance(sfxPathSuccess).start();
            }
        }
    }
}

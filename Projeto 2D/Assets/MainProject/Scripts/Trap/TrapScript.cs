using System;
using System.Collections;
using System.Collections.Generic;
using Folders.HaFolder;
using UnityEngine;

namespace MainProject.Scripts.Trap
{
    public class TrapScript : MonoBehaviour
    {
        private FMOD.Studio.EventInstance sfxEvent;

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
            }
            else{
                switch (objectElement)
                {
                    case Enums.Element.GEO:
                        sfxEvent = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Traps/Positive/sfx_trap_positive_earth");
                        sfxEvent.start();
                        break;
                    case Enums.Element.PYRO:
                        sfxEvent = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Traps/Positive/sfx_trap_positive_fire");
                        sfxEvent.start();
                        break;
                    case Enums.Element.ELECTRO:
                        sfxEvent = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Traps/Positive/sfx_trap_positive_electric");
                        sfxEvent.start();
                        break;
                    case Enums.Element.HYDRO:
                        sfxEvent = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Traps/Positive/sfx_trap_positive_water");
                        sfxEvent.start();
                        break;
                }
            }
        }
    }
}

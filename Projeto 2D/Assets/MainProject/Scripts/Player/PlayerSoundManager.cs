using System;
using System.Collections;
using System.Collections.Generic;
using FMOD;
using FMODUnity;
using UnityEngine;
using Debug = UnityEngine.Debug;
using STOP_MODE = FMOD.Studio.STOP_MODE;

namespace MainProject.Scripts.Player
{
    public class PlayerSoundManager : MonoBehaviour
    {
        public GameObject player;
        private MainProject.Scripts.Player.PlayerStatus playerStatusRef;
        private FMOD.Studio.EventInstance sfxEvent;

        private bool isPlaying;
        private MainProject.Enums.Element currentElement;

        private void Awake()
        {
            playerStatusRef = player.GetComponent<MainProject.Scripts.Player.PlayerStatus>();
            sfxEvent = FMODUnity.RuntimeManager.CreateInstance("event:/SFX/Footsteps/sfx_footstep");
            sfxEvent.stop(STOP_MODE.IMMEDIATE);
            isPlaying = false;

        }

        private void Update()
        {
            onElementChangeCorrectFootstep();
            switch (playerStatusRef.isWalking)
            {
                case true when !isPlaying:
                    playFootStep();
                    isPlaying = true;
                    break;
                case false when isPlaying:
                    sfxEvent.stop(STOP_MODE.ALLOWFADEOUT);
                    isPlaying = false;
                    break;
            }
        }

        private void playFootStep()
        {
            sfxEvent.start();
        }

        private void onElementChangeCorrectFootstep()
        {
            if (playerStatusRef.objectElement == currentElement) return;
            switch (playerStatusRef.objectElement)
            {
                case Enums.Element.NONE:
                    currentElement = Enums.Element.NONE;
                    sfxEvent.setParameterByName("Footstep", 0f);
                    break;
                case Enums.Element.HYDRO:
                    currentElement = Enums.Element.HYDRO;
                    sfxEvent.setParameterByName("Footstep", 1f);
                    break;
                case Enums.Element.GEO:
                    currentElement = Enums.Element.GEO;
                    sfxEvent.setParameterByName("Footstep", 2f);
                    break;
                case Enums.Element.PYRO:
                    currentElement = Enums.Element.PYRO;
                    sfxEvent.setParameterByName("Footstep", 3f);
                    break;
                case Enums.Element.ELECTRO:
                    currentElement = Enums.Element.ELECTRO;
                    sfxEvent.setParameterByName("Footstep", 4f);
                    break;
            }
        }

        public void stopSounds()
        {
            sfxEvent.stop(STOP_MODE.IMMEDIATE);
        }
    }
}


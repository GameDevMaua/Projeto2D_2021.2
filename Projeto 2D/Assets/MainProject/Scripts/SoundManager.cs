using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] public ObjectWithSound[] objects;

    private EventInstance sfxEvent;

    private void Awake()
    {
        foreach (var VARIABLE in objects)
        {
            VARIABLE.eventInstance = FMODUnity.RuntimeManager.CreateInstance(VARIABLE.sfxPath);
            VARIABLE.eventInstance.start();
        }
    }

    [Serializable]
    public class ObjectWithSound
    {
        public GameObject objectWithSound;
        public string sfxPath;

        public EventInstance eventInstance;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

public class ElementSoundManager : MonoBehaviour
{
    public string sfxPath;
    private EventInstance sfx;
    
    private void Awake()
    {
        sfx = FMODUnity.RuntimeManager.CreateInstance(sfxPath);
        sfx.start();
    }
}

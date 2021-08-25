using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.PlayerLoop;

public class GenericScript : PlayerAnimation 
{
    private void Awake()
    {
        AnimationAwake();
    }
    
    private void Update()
    {
        AnimationUpdate();
    }
}

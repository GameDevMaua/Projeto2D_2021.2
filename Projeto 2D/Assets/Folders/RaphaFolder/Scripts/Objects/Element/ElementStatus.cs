using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementStatus : ObjectStatus
{
    // Unique trap status behaviour
    private void Awake()
    {
        AwakeObjectStatus();
    }
}

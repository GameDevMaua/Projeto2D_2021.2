using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainProject.Scripts.Element
{
    public class ElementStatus : MainProject.Abstract.ObjectStatus
    {
        // Comportamento único da classe ElementStatus
        private void Awake()
        {
            AwakeObjectStatus();
        }
    }
}

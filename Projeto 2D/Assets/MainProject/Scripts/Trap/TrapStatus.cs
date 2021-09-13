using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainProject.Scripts.Trap
{
    public class TrapStatus : MainProject.Abstract.ObjectStatus
    {
        // Comportamento único da classe TrapStatus
        public void Awake()
        {
            AwakeObjectStatus();
        }
    }
}

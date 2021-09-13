using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainProject.Scripts.Trap
{
    public class TrapAnimation : MainProject.Abstract.ObjectAnimation
    {
        // Comportamento único da classe TrapAnimation
        protected void Awake()
        {
            AwakeObjectAnimation();
        }
    }
}

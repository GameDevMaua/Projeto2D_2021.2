using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainProject.Scripts.Element
{
    public class ElementAnimation : MainProject.Abstract.ObjectAnimation
    {
        // Comportamento único da classe ElementAnimation
        protected void Awake()
        {
            AwakeObjectAnimation();
        }
    }
}

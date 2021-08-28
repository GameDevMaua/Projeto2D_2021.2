using System;
using System.Collections;
using System.Collections.Generic;
using Folders.HaFolder;
using UnityEngine;

public class TrapScript1 : ElementalObjects
{

    private List<Element.ElementType> copy;
    private ElementScript elementScript = new ElementScript();
    private void OnTriggerEnter2D(Collider2D other)
    {
        copy = elementScript.GetList();
        if (copy[0]== currentElement)
        {
            ClearElement(copy);
        }
        else
        {
            Debug.Log("died");
        }
    }
}

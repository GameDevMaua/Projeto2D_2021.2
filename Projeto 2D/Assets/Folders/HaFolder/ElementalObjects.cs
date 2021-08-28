using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ElementalObjects : MonoBehaviour
{
    public Element.ElementType currentElement;
    
    protected void ElementAwake()
    {

    }

    public void AddElement(List<Element.ElementType> list)
    {
        list.Add(currentElement);
    }

    public void ClearElement(List<Element.ElementType> list)
    {
        list.Clear();
    }
    
    
    

}

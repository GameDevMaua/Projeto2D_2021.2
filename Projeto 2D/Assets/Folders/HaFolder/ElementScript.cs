using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Folders.HaFolder
{
    public class ElementScript : ElementalObjects
    {
        public List<Element.ElementType> elementList;
        private void Awake()
        {
            elementList = new List<Element.ElementType>();
        }

        public List<Element.ElementType> GetList()
        {
            return elementList;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Element element = other.GetComponent<Element>();
            if (element != null)
            {
                ClearElement(elementList);
                AddElement(elementList);
                
                Debug.Log("Element: " + currentElement);
            }
        }
    }
}

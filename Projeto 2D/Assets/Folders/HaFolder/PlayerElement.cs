using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

namespace Folders.HaFolder
{
    public class PlayerElement:MonoBehaviour
    {
        private List<Element.ElementType> elementList;

        private void Awake()
        {
            elementList = new List<Element.ElementType>();
        }

        public void AddElement(Element.ElementType element)
        {
            elementList.Add(element);
        }

        public void RemoveElement(Element.ElementType element)
        {
            elementList.Remove(element);
        }

        public bool ContainsElement(Element.ElementType element)
        {
            return elementList.Contains(element);
        }

        private void OnTriggerEnter2D (Collider2D collider)
        {
            Element element = collider.GetComponent<Element>();
            if (element != null & elementList.Count==0)
            {
                AddElement(element.GetElementType());
                Destroy(element.gameObject);
            }

            TrapScript elementDoor = collider.GetComponent<TrapScript>();
            if (elementDoor != null)
            {
                if (ContainsElement(elementDoor.GetElementType()))
                {
                    elementDoor.OpenTrap();
                    RemoveElement(elementDoor.GetElementType());
                }
            }
        }
    }
}
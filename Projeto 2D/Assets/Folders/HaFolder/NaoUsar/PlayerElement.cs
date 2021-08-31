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
            if (element != null)
            { 
                elementList.Clear();
             //   AddElement(element.GetElementType());
            }

            
            TrapScriptTemp elementDoor = collider.GetComponent<TrapScriptTemp>();
            
            if (elementDoor != null)
            {
                if (ContainsElement(elementDoor.GetElementType()))
                {
                    RemoveElement(elementDoor.GetElementType());
                }
                else
                {
                    // Respawn player (checkpoint):
                    //elementDoor.RespawnPlayer(this.gameObject);
                    
                    // LoadScene:
                    elementDoor.LoadScene();
                }
            }
        }
    }
}
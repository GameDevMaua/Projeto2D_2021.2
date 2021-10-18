using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainProject.Scripts.Dialogue
{
    public class DialogueFloor : MonoBehaviour
    {
        public TriggerDialogue trigger;

        public void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player")) trigger.StartDialogue();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDialogue : MonoBehaviour
{
    public TriggerDialogue trigger;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") == true)
        {
            trigger.StartDialogue();
        }
    }
}

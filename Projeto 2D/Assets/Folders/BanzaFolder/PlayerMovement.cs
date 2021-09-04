using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public KeyCode UpKey;
    public KeyCode DownKey;
    public KeyCode LeftKey;
    public KeyCode RightKey;
    public float Speed = 2.5f;

    private Direction LastDirection;
    private Rigidbody2D Rigidbody2DReference;

    private void Start()
    {
        Rigidbody2DReference = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKey(UpKey))
        {
            Rigidbody2DReference.velocity = new Vector2(Rigidbody2DReference.velocity.x, Speed);
        }

        else if (Input.GetKey(DownKey))
        {
            Rigidbody2DReference.velocity = new Vector2(Rigidbody2DReference.velocity.x, -Speed);
        }

        else
        {
            Rigidbody2DReference.velocity = new Vector2(Rigidbody2DReference.velocity.x, 0);
        }

        if (Input.GetKey(RightKey))
        {
            Rigidbody2DReference.velocity = new Vector2(Speed, Rigidbody2DReference.velocity.y);
        }
        
        else if (Input.GetKey(LeftKey))
        {
            Rigidbody2DReference.velocity = new Vector2(-Speed, Rigidbody2DReference.velocity.y);
        }

        else
        {
            Rigidbody2DReference.velocity = new Vector2(0, Rigidbody2DReference.velocity.y);
        }
            
        
    }
}

    


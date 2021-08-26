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
    public float Speed = 2.0f;

    private Direction LastDirection;
    private Rigidbody2D Rigidbody2DReference;

    private void Update()
    {
        if (Input.GetKey(UpKey)) 
            transform.Translate(Vector2.up * Speed);
            
        if (Input.GetKey(DownKey))
            transform.Translate(Vector2.down * Speed);
            
        if (Input.GetKey(LeftKey))
            transform.Translate(Vector2.left * Speed);
            
        if (Input.GetKey(RightKey)) 
            transform.Translate(Vector2.right * Speed);


        Rigidbody2DReference = GetComponent<Rigidbody2D>();
            
    }
    
    

}


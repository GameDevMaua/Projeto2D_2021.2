using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CindyPlayerMovement : MonoBehaviour
{
    private float moveX;
    private float moveY;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    Vector2 movement;

    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        movement = new Vector2(moveX, moveY);
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x*moveSpeed,movement.y*moveSpeed );
    }
}

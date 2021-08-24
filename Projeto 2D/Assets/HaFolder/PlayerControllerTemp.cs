using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerTemp : MonoBehaviour
{
    public Rigidbody2D RB;
    public float moveSpeed;
    public KeyCode esquerda;
    public KeyCode direita;
    public KeyCode cima;
    public KeyCode baixo;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(esquerda))
        {
            RB.velocity = new Vector2(-moveSpeed, RB.velocity.y);
        } else if (Input.GetKey(direita))
        {
            RB.velocity = new Vector2(moveSpeed, RB.velocity.y);
        }
        else
        {
            RB.velocity = new Vector2(0, RB.velocity.y);
        }

        if (Input.GetKey(cima))
        {
            RB.velocity = new Vector2(RB.velocity.x, moveSpeed);
        } else if (Input.GetKey(baixo))
        {
            RB.velocity = new Vector2(RB.velocity.x, -moveSpeed);
        } else
        {
            RB.velocity = new Vector2(RB.velocity.x, 0);
        }

    }
}

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
   
   private void Awake()
   {
      if (UpKey == KeyCode.None)
         UpKey = KeyCode.W;
      
      
      if (DownKey == KeyCode.None)
         DownKey = KeyCode.S;
      
      
      if (LeftKey == KeyCode.None)
         LeftKey = KeyCode.A;
      
      
      if (RightKey == KeyCode.None)
         RightKey = KeyCode.D;




      Rigidbody2DReference = GetComponent<Rigidbody2D>();
      
   }

}

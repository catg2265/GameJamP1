using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
   private Rigidbody2D rb;
       private float movementX;
       public float speed = 1;
   
       private bool touchGrass;
       private float jumpY;
       public float jumpHeight = 1;
       
       void Start()
       {
           rb = GetComponent<Rigidbody2D>();
       }
   
       void OnMove(InputValue movementValue)
       {
           Vector2 movementVector = movementValue.Get<Vector2>();
           movementX = Mathf.RoundToInt((movementVector.x));
   
           Vector2 jumpVector = movementValue.Get<Vector2>();
           jumpY = Mathf.RoundToInt((jumpVector.y));
   
           if (jumpVector.y > 0)
           {
               if (touchGrass)
               {
                   rb.velocity = new Vector2(jumpVector.x, jumpY * jumpHeight);
                   touchGrass = false;
               }
           }
       }
   
       void OnCollisionEnter2D(Collision2D other)
       {
           if (other.gameObject.CompareTag("Ground"))
           {
               touchGrass = true;
           }
       }
       void FixedUpdate()
       {
           rb.velocity = new Vector2(movementX * speed, rb.velocity.y);
       }
    }

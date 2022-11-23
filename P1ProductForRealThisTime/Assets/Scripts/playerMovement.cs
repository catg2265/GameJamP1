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
       
       public GameObject attackRay;
       [SerializeField] private float attackRayRange;
       public LayerMask layerMask;
       public GameObject enemy;
       private GameObject foundEnemy;
       
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


       private void OnFire()
       {
           RaycastHit2D hit = Physics2D.Raycast(attackRay.transform.position, Vector2.right, attackRayRange, layerMask);

           if (hit.collider != null)
           {
               print("you hit");
               string raycastreturn = hit.collider.gameObject.name;
               foundEnemy = GameObject.Find(raycastreturn);
               foundEnemy.GetComponent<enemy>().isHit = true;
               Debug.DrawRay(attackRay.transform.position, Vector2.right * attackRayRange, Color.blue);
           }
           else
           {
               print("you didnt it");
               Debug.DrawRay(attackRay.transform.position, Vector2.right * attackRayRange, Color.red);
           }
       }

    }

using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Serialization;

public class playerMovement : MonoBehaviour
{
   private Rigidbody2D rb;
   private float movementX;
   public float speed = 1;

   private bool touchGrass;
   public bool isFlipped;
   private float movementY;
   public float jumpHeight = 1;
       
   public GameObject attackRay;
   [SerializeField] private float attackRayRange;
   public LayerMask layerMask;
   public GameObject enemy;
   GameObject foundEnemy;
   [SerializeField] private Animator thorAnima;
   public GameObject thorsHammer;
   public GameObject attackThrow;
   public bool hammerThrown = false;
   
   
   void Start() 
   {
       rb = GetComponent<Rigidbody2D>();
       thorsHammer.GetComponent<Projectile>().direction = false;
   }

   void OnMove(InputValue movementValue)
   {
       Vector2 movementVector = movementValue.Get<Vector2>();
       movementX = Mathf.RoundToInt((movementVector.x));
   
       Vector2 jumpVector = movementValue.Get<Vector2>();
       movementY = Mathf.RoundToInt((jumpVector.y));
   
       if (jumpVector.y > 0)
       {
           if (touchGrass)
           {
               touchGrass = false;
               rb.velocity = new Vector2(jumpVector.x, movementY * jumpHeight);
                   
               thorAnima.SetBool("touchGrass", false);
           }
       }

       if (movementVector.x > 0 || movementVector.x < 0)
       {
           thorAnima.SetBool("Velocity", true);
       }
       else
       {
           thorAnima.SetBool("Velocity", false);
       }

       if (movementVector.x < 0)
       {
           transform.localScale = new Vector3(-1, 1, 1);
           isFlipped = true;
           thorsHammer.GetComponent<Projectile>().direction = true;
       }
       else if (movementVector.x > 0)
       {
           transform.localScale = new Vector3(1, 1, 1);
           isFlipped = false;
           thorsHammer.GetComponent<Projectile>().direction = false;
       }
   }
   void FixedUpdate()
   { 
       rb.velocity = new Vector2(movementX * speed, rb.velocity.y); 
   }
   void OnCollisionEnter2D(Collision2D other)
   {
       if (other.gameObject.CompareTag("Ground"))
       {
           touchGrass = true;
           thorAnima.SetBool("touchGrass", true);
       }
           
   }
       

   void Raycast(Vector2 direction)
   {
       RaycastHit2D hit = Physics2D.Raycast(attackRay.transform.position, direction, attackRayRange, layerMask);
       if (hit.collider != null)
       {
           string raycastreturn = hit.collider.gameObject.name;
           foundEnemy = GameObject.Find(raycastreturn);
           foundEnemy.GetComponent<enemy>().isHit = true;
       } 
   }

       void DelayedRaycast()
       {
           if (!isFlipped)
           {
               Raycast(Vector2.right);
           }
           else if (isFlipped)
           {
               Raycast(Vector2.left);
           }
       }
       private void OnFire()
       {
               thorAnima.SetTrigger("meleeAttack");
               Invoke(nameof(DelayedRaycast), 0.55f);
       }

       void HammerThrow()
       {
           GameObject hammer = Instantiate(thorsHammer, attackThrow.transform.position, Quaternion.identity);
       }

       private void OnFireRight()
       {
           if (!hammerThrown)
           {
               thorAnima.SetTrigger("rangedAttack");
               Invoke(nameof(HammerThrow), 0.6f);
               hammerThrown = true;
           }
       }

    }

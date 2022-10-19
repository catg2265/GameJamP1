using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hunter : MonoBehaviour

{
    GameObject newArrow;

    public GameObject arrow;
   
    public GameObject crosshair;

    private Rigidbody2D rb;

    private SpriteRenderer flip;

    public Animator anime;


    private float moveX;

    private float crosshairX;


    public float speed = 5f;

    public float jumpHeight = 0;


    public Transform shotPoint;


    private bool touchGrass = false;

    private bool flipX;

    private bool move;

    private float yes;

    public bool Gamebow;
    public bool GamenonBow;

    private Animator Bow;
    


    public Vector3 targetoffset;
    public Stopwatch stopwatch;
    public float TimeToMaxDistance;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            touchGrass = true;
        }
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        moveX = movementVector.x;
        anime.SetFloat("speed", Mathf.Abs(moveX));
            
        if (touchGrass && movementVector.y >= 0.6f)
        {
            Vector2 jump = new Vector2(0f, jumpHeight);
            rb.AddForce(jump * jumpHeight);
            touchGrass = false; 
        }

    }

    public void OnFireStart(InputValue context)
    {
        
        yes = context.Get<float>();
        if (yes == 1f && stopwatch == null)
        {
            
            Gamebow = true;
            stopwatch = Stopwatch.StartNew();
        }
        else if (yes == 0f)
        {
            Gamebow = false;
            shoot(crosshair.transform.position);
            stopwatch = null;
            
           

        }
        move = true;
    }

    private void shoot(Vector3 launchForce)
    {
            newArrow = Instantiate(arrow, shotPoint.position, shotPoint.rotation);
            newArrow.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce.x * 1.5f;
       
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        flip = GetComponent<SpriteRenderer>();
        crosshair.transform.position += Vector3.down;

        Bow = gameObject.GetComponent<Animator>();
        


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        if (yes == 1 && move)
        {
            if(stopwatch != null && ((stopwatch.ElapsedMilliseconds / 1000f) / TimeToMaxDistance) <= 1f)
            {
                
                crosshair.gameObject.SetActive(true);
                crosshair.transform.position = Vector3.Lerp(transform.position + Vector3.down, transform.position +  Vector3.down + targetoffset, (stopwatch.ElapsedMilliseconds / 1000f) / TimeToMaxDistance);
                
            }
        }
        else if(yes == 0)
        {
            
            crosshair.transform.position = transform.position + Vector3.down;
            crosshair.gameObject.SetActive(false);
        }

        Vector2 bowPosition = transform.position + Vector3.down;
        Vector2 crosshairPos = crosshair.transform.position;
        Vector2 direction = crosshairPos - bowPosition;
        transform.right = direction;



        if (touchGrass)
        {
            if (rb.velocity.x <= speed)
            {
                Vector2 movement = new Vector2(moveX, 0f);
                rb.AddForce(movement * speed);
            }
        }
        else if(!touchGrass)
        {
            Vector2 movement = new Vector2(moveX, 0f);
            rb.AddForce(movement * (speed * 0.4f));
            
        }

        if(moveX > 0)
        {
            flip.flipX = false;
        }
        
        if(moveX < 0) 
        {
            flip.flipX = true;
        }

       


    }

    private void Update()
    {
        GetComponent<Animator>().SetBool("Bow", Gamebow);
        
    }






}

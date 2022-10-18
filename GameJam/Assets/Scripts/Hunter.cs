using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hunter : MonoBehaviour
{
    public GameObject hunter;

    private Rigidbody2D rb;

    private SpriteRenderer flip;

    public Animator anime;

    private float moveX;

    public float speed = 5f;

    public float jumpHeight = 0;

    private bool touchGrass = false;

    private bool flipX;
    private Vector2 movement;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            touchGrass = true;
        }
    }

    private void OnMove(InputValue movementValue)
    {
        movement = movementValue.Get<Vector2>();
        //moveX = movementVector.x;
        anime.SetFloat("speed", Mathf.Abs(moveX));
            
        if (touchGrass && movement.y >= 0.6f)
        {
            Vector2 jump = new Vector2(0f, jumpHeight);
            rb.AddForce(jump * jumpHeight);
            touchGrass = false; 
        }

    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        flip = GetComponent<SpriteRenderer>();

        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (touchGrass)
        {
            if (rb.velocity.x <= speed)
            {
                //Vector2 movement = new Vector2(moveX, 0f);
                rb.AddForce(movement * speed);
                //rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);
            }
        }
        else
        {
            //Vector2 movement = new Vector2(moveX, 0f);
            rb.AddForce(movement * (speed * 0.4f));
            //rb.velocity = new Vector2(movement.x * speed * 0.4f, rb.velocity.y);
        }

        if(movement.x > 0)
        {
            flip.flipX = false;
        }
        
        if(movement.x < 0) 
        {
            flip.flipX = true;
        }

    }







   
}

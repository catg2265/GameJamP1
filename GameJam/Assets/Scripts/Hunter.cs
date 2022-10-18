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

    public float speed = 0;

    public float jumpHeight = 0;

    private bool touchGrass = false;

    private bool flipX;

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
                Vector2 movement = new Vector2(moveX, 0f);
                rb.AddForce(movement * speed);
            }
        }
        else
        {
            Vector2 movement = new Vector2(moveX, 0f);
            rb.AddForce(movement * speed * 0.4f);
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







   
}

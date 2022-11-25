using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D c2D;
    private SpriteRenderer sr;
    [SerializeField] private GameObject player;
    [SerializeField] private Animator anim;
    public float speed = 1f;

    public bool isHit = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        c2D = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (isHit)
        {
            
            anim.SetBool("IsDead", true);
            rb.bodyType = RigidbodyType2D.Static;
            c2D.enabled = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isHit)
        {
            if (player.transform.position.x < transform.position.x)
            {
                Vector2 left = Vector2.left;
                rb.velocity = new Vector2(left.x * speed, rb.velocity.y);
                sr.flipX = false;

            }
            else if (player.transform.position.x > transform.position.x)
            {
                Vector2 right = Vector2.right;
                rb.velocity = new Vector2(right.x * speed, rb.velocity.y);
                sr.flipX = true;
            }
        }
    }
    
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("Bite");
        }
    }
}

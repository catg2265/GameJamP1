using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameObject player;
    public float speed = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    
    {
        if (player.transform.position.x < transform.position.x)
        {
            Vector2 left = Vector2.left;
            rb.velocity = new Vector2(left.x * speed, rb.velocity.y);

        }
        
        else if (player.transform.position.x > transform.position.x)
        {
            Vector2 right = Vector2.right;
            rb.velocity = new Vector2(right.x * speed, rb.velocity.y);
        }
        
    }
    
    public void OnCollisionEnter2D(Collision2D life)
    {
        if (life.gameObject.CompareTag("Player"))
        {
            player.gameObject.SetActive(false);
        }
    }
}

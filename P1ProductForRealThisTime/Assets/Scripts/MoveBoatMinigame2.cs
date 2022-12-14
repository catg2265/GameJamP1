using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MoveBoatMinigame2 : MonoBehaviour
{
    public float speedX = 5f;
    public float speedY = 5f;
    
    private float movementX;
    private float movementY;
    private Vector2 movement;

    [SerializeField] private Transform anchorTransform;
    [SerializeField] private Rigidbody2D anchor;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;

    public float whalesCaught;

    public Vector3 anchorStartPos;

    private void Update()
    {
        if (whalesCaught > 0)
        {
            anim.SetFloat("whales", whalesCaught);
        }
        else if (whalesCaught > 1)
        {
            anim.SetFloat("whales", whalesCaught);
        }

        if (anchorTransform.position.y < 0)
        {
            anchorTransform.position = anchorStartPos+transform.position;
        }

        if (anchorTransform.position.y > 6)
        {
            anchorTransform.position = anchorStartPos + new Vector3(transform.position.x, 0, 0);
        }
    }
    

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movementX * speedX, rb.velocity.y);
        anchor.velocity = new Vector2(rb.velocity.x, movementY * speedY);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Wall"))
        {
            anchor.bodyType = RigidbodyType2D.Static;
        }
        
        if (col.gameObject.CompareTag("Wall") && whalesCaught == 2)
        {
            anchor.bodyType = RigidbodyType2D.Static;
            SceneManager.LoadScene("Cutscene4");
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            anchorTransform.position = anchorStartPos+transform.position;
            anchor.bodyType = RigidbodyType2D.Dynamic;
        }
    }

    void OnMoveAnchor(InputValue input)
    {
        movement = input.Get<Vector2>();
        movementX = Mathf.RoundToInt(movement.x);
        movementY = Mathf.RoundToInt(movement.y);
    }
    
}

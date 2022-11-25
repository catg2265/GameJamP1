using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveBoatMinigame2 : MonoBehaviour
{
    public float speedX = 5f;
    public float speedY = 5f;
    
    private float movementX;
    private float movementY;
    private Vector2 movement;
    
    [SerializeField] private Rigidbody2D anchor;
    [SerializeField] private Rigidbody2D rb;

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movementX * speedX, rb.velocity.y);
        anchor.velocity = new Vector2(rb.velocity.x, movementY * speedY);
    }

    void OnMoveAnchor(InputValue input)
    {
        movement = input.Get<Vector2>();
        movementX = Mathf.RoundToInt(movement.x);
        movementY = Mathf.RoundToInt(movement.y);
    }
    
}

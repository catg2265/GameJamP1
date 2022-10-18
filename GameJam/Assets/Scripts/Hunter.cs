using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Hunter : MonoBehaviour
{
    public GameObject hunter;

    private Rigidbody2D rb;

    private float moveX;

    public float speed = 0;

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        moveX = movementVector.x;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 movement = new Vector2(moveX, 0f);
        rb.AddForce(movement * speed);
    }

   
}

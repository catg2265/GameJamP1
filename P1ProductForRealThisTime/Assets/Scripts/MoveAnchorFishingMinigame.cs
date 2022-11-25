using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MoveAnchorFishingMinigame : MonoBehaviour
{
    public float speed = 2f;

    [SerializeField] private Rigidbody2D rb;
    
    [SerializeField] private Vector3 startPosition;

    [SerializeField] private Vector3 endPosition;

    private Vector2 movement;
    private float movementX;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPosition, Time.deltaTime * speed);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(movementX * speed, rb.velocity.y);
    }

    void OnMoveAnchor(InputValue movementValue)
    {
        movement = movementValue.Get<Vector2>();
        movementX = Mathf.RoundToInt(movement.x);
    }
}
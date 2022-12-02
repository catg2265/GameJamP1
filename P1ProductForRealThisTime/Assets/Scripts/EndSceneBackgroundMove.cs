using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndSceneBackgroundMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    public Vector3 startPos;
    public Vector3 endPos;
    public Vector2 move = new Vector2(1, 0);
    public float speed = 5f;

    private void Start()
    {
        transform.position = startPos;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + move * (speed * Time.fixedTime));
        if (transform.position.x <= endPos.x)
        {
            transform.position = startPos;
        }
    }
}

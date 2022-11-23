using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTestBackground : MonoBehaviour
{
    public float Speed = 50f;
    public Rigidbody2D rb;

    Vector2 movement;
    
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //input
    }

    //using fixedupdate because its more consistent than update, since it dosent depend on my own fps - it's fixed at 50 fps.
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * Speed * Time.fixedDeltaTime);
    }
}

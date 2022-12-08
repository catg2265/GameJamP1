using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Projectile : MonoBehaviour
{
    private Stopwatch stopwatch;
    public GameObject player;
    
    private Vector3 startPos;
    private Vector3 endPos;
    private Vector3 throwRangeRight;
    private Vector3 throwRangeLeft;
    
    public float rotationSpeed = 10f;
    public float range = 1f;
    private float throwTime = 0.5f;
    
    public bool direction;
    private bool maxDistReached = false;
    
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        startPos = transform.position;
        throwRangeLeft = new Vector3(transform.position.x - range, transform.position.y);
        throwRangeRight = new Vector3(transform.position.x + range, transform.position.y);
        stopwatch = new Stopwatch();
    }
    private void FixedUpdate()
    {
        
        transform.Rotate(Vector3.back * rotationSpeed, Space.Self);
        
        stopwatch.Start();

        float throwTimeRatio = (stopwatch.ElapsedMilliseconds / 1000f) / throwTime;

        if (!maxDistReached && !direction)
        {
            transform.position = Vector3.Lerp(startPos, throwRangeRight, throwTimeRatio);
        }
        else if (maxDistReached && !direction)
        {
            transform.position = Vector3.Lerp(endPos, player.transform.position, throwTimeRatio);
        }
        
        if (!maxDistReached && direction)
        {
            transform.position =
                Vector3.Lerp(startPos, throwRangeLeft, throwTimeRatio);
        }
        else if (maxDistReached && direction)
        {
            transform.position = Vector3.Lerp(endPos, player.transform.position, throwTimeRatio);
        }

        if (transform.position == throwRangeRight)
        {
            MaxDistReached();
        }
        else if (transform.position == throwRangeLeft)
        {
            MaxDistReached();
        }
    }
    private void MaxDistReached()
    {
        maxDistReached = true;
        endPos = transform.position;
        stopwatch = Stopwatch.StartNew();
    } 
    private void OnTriggerEnter2D(Collider2D col)
         {
             if (col.gameObject.CompareTag("Player") && maxDistReached)
             {
                 col.GetComponent<playerMovement>().hammerThrown = false;
                 Destroy(gameObject);
             }
     
             if (col.gameObject.CompareTag("Enemy"))
             {
                 col.GetComponent<enemy>().isHit = true;
             }

             if (col.gameObject.CompareTag("Ground"))
             {
                 maxDistReached = true;
             }
         }
}

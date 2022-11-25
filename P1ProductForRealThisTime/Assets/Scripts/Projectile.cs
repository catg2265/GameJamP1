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
    public GameObject player;
    public float rotationSpeed = 5;
    public float range = 5;

    public bool direction;
    private bool isMoving = false;
    private Vector3 startPos;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            
            Destroy(gameObject);
        }
    }

    void Start()
    {
        startPos = transform.position;
    }

    Vector3 computeNextPos(Vector3 pos, bool goRight)
    {
        Vector3 addVector = Vector3.right / 5;
        Vector3 minusVector = Vector3.left/ 5;

        if (!goRight)
        {
            return pos + addVector;
        }
        else
        {
            return pos + minusVector;
        }
    }

    void Throw(bool direction)
    {
        print("");
        transform.position = computeNextPos(transform.position, direction);
    }
    
    /*void Throw()
    {
        stopwatch = new Stopwatch();
        stopwatch.Start();
        Vector3 throwRange = new Vector3(10, 0, 0);
        float timeToMaxDist = 2;
        rb.velocity = Vector3.Lerp(transform.position, transform.position + throwRange, (stopwatch.ElapsedMilliseconds / 1000f) / timeToMaxDist);
    }*/

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.back * rotationSpeed, Space.Self);

        Vector3 throwRangeRight = Vector3.right * range;
        Vector3 throwRangeLeft = Vector3.left * range;
        
        
        if (!direction && transform.position.x <= throwRangeRight.x && !isMoving)
        {
            print("Hej");
            Throw(false);
        }
        else if (!direction)
        {
            isMoving = true;
            print("hej1");
            Throw(true);
        }

        if (direction && transform.position.x >= throwRangeLeft.x && !isMoving)
        {
            Throw(true);
        }
        else if (direction)
        {
            isMoving = true;
            Throw(false);
        }
        
    }
}

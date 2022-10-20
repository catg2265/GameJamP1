using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class KuduController : MonoBehaviour
{
    public Animator animator;
    public bool alert = false;
    public bool isRunning = false;
    public float farCounter = 0f;
    public float closeCounter = 0f;
    public bool stopCount = true;
    public Transform playerTransform;
    public float alertDist = 5f;
    public float kuduSpeed = 5f;
    public float kuduHealth = 100f;

    public SpriteRenderer sprite;
    //private bool isFacingRight = true;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Alert();
        AnimateKudu(isRunning, alert);
        if (alert & !isRunning)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
        if (isRunning)
        {
            transform.position += Vector3.right * (kuduSpeed * Time.deltaTime);
        }
        if (kuduHealth <= 50)
        {
            // play damaged animation
            // change run animation to slower
        }
        else if (kuduHealth <= 0)
        {
            //play death animation
            Destroy(gameObject);
        }

        if (transform.position.x > 20)
        {
            Destroy(gameObject);
        }
    }

    void Alert()
    {
        if (Vector2.Distance(playerTransform.position,transform.position) < alertDist)
        {
            farCounter = 0f;
            alert = true;
            closeCounter += Mathf.Lerp(0, 1, Time.deltaTime);
            if (closeCounter > 2)
            {
                farCounter = 10f;
                isRunning = true;
                closeCounter = 0f;
            }
        }
        else
        {
            closeCounter = 0f;
            if (!stopCount)
            {
                farCounter += Mathf.Lerp(0, 1, Time.deltaTime);
                if (farCounter > 10)
                {
                    isRunning = false;
                    farCounter = 0;
                }

                alert = false;
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }

    void AnimateKudu(bool run, bool spook)
    {
        animator.SetBool("Alert", spook);
        animator.SetBool("Close", run);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, alertDist);
    }
}

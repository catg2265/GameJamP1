using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.DualShock;

public class KuduController : MonoBehaviour
{
    public Animator animator;
    public RuntimeAnimatorController undamaged;
    public RuntimeAnimatorController damaged;
    public bool alert = false;
    public bool isRunning = false;
    public float farCounter = 0f;
    public float closeCounter = 0f;
    public float extraCounter;
    public float runningCounter;
    public bool stopCount = true;
    public Transform playerTransform;
    public Transform lvl2Pos;
    public Transform lvl3Pos;
    public float alertDist = 5f;
    public float kuduSpeed = 5f;
    public float kuduHealth = 100f;
    public int arrowHits;
    public bool headshot;
    public int currentLevel = 1;

    SpriteRenderer sprite;
    public Camera cam;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        headshot = false;
        arrowHits = 0;
        animator.runtimeAnimatorController = undamaged;
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
            
            runningCounter += Mathf.Lerp(0, 1, Time.deltaTime);
            if (runningCounter > 7)
            {
                isRunning = false;
                if (currentLevel == 1)
                {
                    transform.position = lvl2Pos.position;
                    runningCounter = 0f;
                    currentLevel++;
                }
                else if (currentLevel == 2)
                {
                    transform.position = lvl3Pos.position;
                    runningCounter = 0f;
                    currentLevel++;
                }
            }
        }
        if (kuduHealth <= 50 && kuduHealth > 0)
        {
            animator.runtimeAnimatorController = damaged as RuntimeAnimatorController;
            // !!!! Remember to stop player movement until teleported to next level
            
            extraCounter += Mathf.Lerp(0, 1, Time.deltaTime);
            if (extraCounter > 1)
            {
                isRunning = true;
                kuduSpeed = 3f;
            }
            
        }
        else if (kuduHealth <= 0)
        {
            isRunning = false;
            if (arrowHits == 1 && headshot)
            {
                //play headshot death 1 arrow
                animator.SetTrigger("onearrowhead");
            }
            else if (arrowHits == 2 && headshot)
            {
                //play headshot death 2 arrows
                animator.SetTrigger("twoarrowhead");
            }
            else if (arrowHits == 2 && !headshot)
            {
                //play bodyshot death 2 arrows
                animator.SetTrigger("bodyshot");
            }
        }

       if (arrowHits == 1 && !GameObject.FindWithTag("Player").GetComponent<Hunter>().KuduHit)
        {
            tpPlayer();
        }
        if (arrowHits == 2 && !GameObject.FindWithTag("Player").GetComponent<Hunter>().KuduHit)
        {
            tpPlayer();
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

    void tpPlayer()
    {
        GameObject.FindWithTag("Player").GetComponent<Hunter>().KuduhitCounter++;
        GameObject.FindWithTag("Player").GetComponent<Hunter>().KuduHit = true;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, alertDist);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KuduController : MonoBehaviour
{
    public Animator animator;
    public bool alert = false;
    public float farCounter = 0f;
    public float closeCounter = 0f;
    public bool stopCount = true;
    public Transform playerTransform;
    public float alertDist = 5f;
    
    void Update()
    {
        
        Alert();
        
    }

    void Alert()
    {
        if (Vector2.Distance(playerTransform.position,transform.position) < alertDist)
        {
            farCounter = 0f;
            
            animator.SetBool("Alert", true);
            closeCounter += Mathf.Lerp(0, 1, Time.deltaTime);
            if (closeCounter > 2)
            {
                farCounter = 10f;
                animator.SetBool("To_Close", true);
                closeCounter = 0f;
            }
        }
        else
        {
            closeCounter = 0f;
            if (!stopCount)
            {
                //animator.SetBool("Alert", false);
                farCounter += Mathf.Lerp(0, 1, Time.deltaTime);
                if (farCounter > 10)
                {
                    animator.SetBool("To_Close", false);
                    farCounter = 0;
                    //stopCount = true;
                }
                animator.SetBool("Alert", false);
            }
            
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, alertDist);
    }
}

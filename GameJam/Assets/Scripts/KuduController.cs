using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KuduController : MonoBehaviour
{
    public Animator animator;
    public bool alert = false;
    public float counter = 0f;
    public bool stopCount = false;
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
            animator.SetBool("Alert", true);
            counter += Mathf.Lerp(0, 1, Time.deltaTime);
            if (counter > 2)
            {
                animator.SetBool("To_Close", true);
                counter = 0f;
            }
        }
        else
        {
            if (!stopCount)
            {
                counter += Mathf.Lerp(0, 1, Time.deltaTime);
                if (counter > 10)
                {
                    animator.SetBool("To_Close", false);
                    counter = 0;
                }
            }
            
            animator.SetBool("Alert", false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, alertDist);
    }
}

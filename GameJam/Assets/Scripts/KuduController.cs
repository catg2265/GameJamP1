using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KuduController : MonoBehaviour
{
    public Animator animator;

    public bool alert = false;

    public float counter = 0f;
    // Update is called once per frame
    void Update()
    {
        counter = 0f;
        if (!alert)
        {
            animator.SetBool("Alert", alert);
            counter += Mathf.Lerp(0, 1, Time.deltaTime);
            if (counter > 5)
            {
                animator.SetBool("To_Close", true);
                alert = false;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            alert = true;
        }
    }
}

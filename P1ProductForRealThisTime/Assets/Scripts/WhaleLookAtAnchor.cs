using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleLookAtAnchor : MonoBehaviour
{
    public float openMouthDistance = 3f;
    
    [SerializeField] private Animator anim;
    [SerializeField] private Transform anchor;

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(anchor.position, transform.position) < openMouthDistance)
        {
            anim.SetBool("MouthOpen", true);
        }
        else
        {
            anim.SetBool("MouthOpen", false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, openMouthDistance);
    }
}

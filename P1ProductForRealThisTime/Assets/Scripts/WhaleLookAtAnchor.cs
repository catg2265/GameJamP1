using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class WhaleLookAtAnchor : MonoBehaviour
{
    public float openMouthDistance = 3f;
    
    [SerializeField] private Animator anim;
    [SerializeField] private Transform anchor;
    [SerializeField] private GameObject boat;
    
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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Anchor"))
        {
            boat.GetComponent<MoveBoatMinigame2>().whalesCaught++;
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, openMouthDistance);
    }
}

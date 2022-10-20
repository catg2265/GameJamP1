using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KuduCritDamage : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Arrow"))
        {
            GetComponent<KuduController>().kuduHealth -= 100f;
            GetComponent<KuduController>().arrowHits++;
            GetComponent<KuduController>().headshot = true;
        }
    }
}

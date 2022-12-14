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
            GetComponentInParent<KuduController>().kuduHealth -= 100f;
            GetComponentInParent<KuduController>().arrowHits++;
            GetComponentInParent<KuduController>().headshot = true;
            //GetComponentInParent<KuduController>().stopCount = false;
        }
    }
}

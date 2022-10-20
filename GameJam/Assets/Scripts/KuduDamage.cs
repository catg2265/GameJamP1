using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KuduDamage : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Arrow"))
        {
            GetComponentInParent<KuduController>().kuduHealth -= 60f;
            GetComponentInParent<KuduController>().arrowHits++;
        }
    }
}

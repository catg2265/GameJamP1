using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEvilEyes : MonoBehaviour
{
    public float delayAnimation = 2f;
    public float activateDistance;
    [SerializeField] private Transform player;
    [SerializeField] private Animator anim;

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(player.position, transform.position) < activateDistance)
        {
            StartCoroutine(StartAnimation());
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, activateDistance);
    }

    IEnumerator StartAnimation()
    {
        yield return new WaitForSeconds(delayAnimation);
        anim.SetTrigger("Activate");
    }
}

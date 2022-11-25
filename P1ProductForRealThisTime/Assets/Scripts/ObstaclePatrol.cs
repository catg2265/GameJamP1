using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePatrol : MonoBehaviour
{
    public float patrolSpeed = 2f;

    public Vector3[] positions;

    private int increment;

    private bool _istransformNotNull;

    // Start is called before the first frame update
    void Start()
    {
        _istransformNotNull = transform != null;
        Vector3 localscale = transform.localScale;
        localscale.x *= -1f;
        transform.localScale = localscale;
    }

    // Update is called once per frame
    void Update()
    {
        if (_istransformNotNull)
        {
            var transform1 = transform;
            Vector3 localscale = transform1.localScale;
            transform.position = Vector3.MoveTowards(transform1.position, positions[increment], Time.deltaTime * patrolSpeed);
            if (transform.position == positions[increment])
            {
                if (increment == positions.Length - 1)
                {
                    increment = 0;
                    localscale.x *= -1f;
                    transform.localScale = localscale;
                }

                else
                {
                    increment++;
                    localscale.x *= -1f;
                    transform.localScale = localscale;
                }
            }
        }
    }
}

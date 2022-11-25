using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropLookAt : MonoBehaviour
{
    [SerializeField] private Vector3 startPosition;

    [SerializeField] private Vector3 endPosition;
    
    public float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, endPosition, Time.deltaTime * speed);
    }
}

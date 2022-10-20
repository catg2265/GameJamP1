using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.Animation;

public class WaterCol : MonoBehaviour
{
    
    public bool Gamedeath;
    private Animator Death;

    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        Death = gameObject.GetComponent<Animator>();
        speed = gameObject.GetComponent<movementTest>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Water"))
        {
            Gamedeath = true;
            GetComponent<Animator>().SetBool("Death?",Gamedeath);
            speed = 0f;
            GetComponent<CapsuleCollider2D>().size = new Vector2(0.2f, 0.5f);


        }
    }
}

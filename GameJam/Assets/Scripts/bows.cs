using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bows : MonoBehaviour
{
    public bool Gamebow;
    public bool GamenonBow;

    private Animator Bow;
    private Animator Nonbow;
    
    void Start()
    {
        Bow = gameObject.GetComponent<Animator>();
        Nonbow = gameObject.GetComponent<Animator>();
    }

   
    void Update()
    {
       
        GetComponent<Animator>().SetBool("Bow",Gamebow);
        GetComponent<Animator>().SetBool("Nonbow", GamenonBow);
        
    }
}

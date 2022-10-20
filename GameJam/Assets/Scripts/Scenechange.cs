using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenechange : MonoBehaviour
{
    
    public Sprite endScene;

    public bool test;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (test)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = endScene;

        }
    }
}

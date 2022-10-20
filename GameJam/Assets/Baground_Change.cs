using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Baground_Change : MonoBehaviour

{
   
    void Start()
    {
        
    }


    void Update()
    {
        if (GameObject.FindWithTag("Kudu").GetComponent<KuduController>().currentLevel == 1)
        {
            Destroy(GameObject.Find("Baground_Sun"));
        }
        
        if (GameObject.FindWithTag("Kudu").GetComponent<KuduController>().currentLevel == 2)
        {
            Destroy(GameObject.Find("Baground_Evening"));
        }
        
        if (GameObject.FindWithTag("Kudu").GetComponent<KuduController>().currentLevel == 3)
        {
            Destroy(GameObject.Find("Baground_Night"));
        }
        
    }
}

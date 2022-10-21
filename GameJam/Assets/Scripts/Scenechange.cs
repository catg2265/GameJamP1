using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenechange : MonoBehaviour
{
    
    public GameObject endScene;
    public GameObject Gameover;

    public bool test;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        //if (GameObject.FindWithTag("Player").GetComponent<Hunter>().KuduhitCounter >= 0 && GameObject.FindWithTag("Kudu").GetComponent<KuduController>().arrowHits == 0 || GameObject.FindWithTag("Player").GetComponent<Hunter>().KuduhitCounter >= 0 && GameObject.FindWithTag("Kudu").GetComponent<KuduController>().arrowHits == 1)
        if (GameObject.FindWithTag("Kudu").GetComponent<KuduController>().currentLevel >= 4 && GameObject.FindWithTag("Kudu").GetComponent<KuduController>().arrowHits == 0 || GameObject.FindWithTag("Kudu").GetComponent<KuduController>().currentLevel >= 4 && GameObject.FindWithTag("Kudu").GetComponent<KuduController>().arrowHits == 1 )
        {
            //this.gameObject.GetComponent<SpriteRenderer>().sprite = endScene;
            //this.gameObject.GetComponent<SpriteRenderer>().sortingLayerID = SortingLayer.NameToID("Endscene");
            endScene.SetActive(true);
        }

        if (GameObject.FindWithTag("Kudu").GetComponent<KuduController>().kuduHealth <= 0)
        {
            //this.gameObject.GetComponent<SpriteRenderer>().sprite = Gameover;
            //this.gameObject.GetComponent<SpriteRenderer>().sortingLayerID = SortingLayer.NameToID("Endscene");
            Gameover.SetActive(true);
        }
    }
}

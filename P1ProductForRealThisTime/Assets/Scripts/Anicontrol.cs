using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anicontrol : MonoBehaviour
{
    [SerializeField] private GameObject Waves;
    [SerializeField] private GameObject background;
    [SerializeField] private Animator m_Animator;
    [SerializeField] private Camera m_Camera;
    //private Vector3 pos = new Vector3(-0.38938f, 2f, 0); 


    
    // Start is called before the first frame update
    IEnumerator Start()
    {
        yield return new WaitForSeconds(3f);
        Waves.SetActive(false);
        background.SetActive(false);
        m_Animator.SetTrigger("Scenechange");
        m_Camera.orthographicSize = 5;
        transform.position = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

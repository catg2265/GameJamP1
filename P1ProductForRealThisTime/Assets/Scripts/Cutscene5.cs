using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cutscene5 : MonoBehaviour
{
    public int changer = 1;
    public Animator Sceneanimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Sceneanimator.SetInteger("Cutscenechange", changer++);
            
        }
        if (Input.GetButton("Jump")&& changer == 4)
        {
            SceneManager.LoadScene("cutscene6");
        }
    }
}
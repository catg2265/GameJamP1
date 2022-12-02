using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Cutscene2 : MonoBehaviour
{
    public int changer = 1;
    public Animator Sceneanimator;
    public int Textchange;

    public TextMeshProUGUI Thor;
    public TextMeshProUGUI Hymir;
    public TextMeshProUGUI Hymir2;
    public TextMeshProUGUI Thor2;

    // Start is called before the first frame update
    void Start()
    {
        Thor.enabled = true;
        Hymir.enabled = false;
        Hymir2.enabled = false;
        Thor2.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Sceneanimator.SetInteger("Cutscenechange", changer++);
            Textchange++;

        }
        if (Input.GetButton("Jump")&& changer == 5)
        {
            SceneManager.LoadScene("Cutscene3");
        }
        if (Textchange == 1)
        {
            Thor.enabled = false;
            Hymir.enabled = true;
        }
        if (Textchange == 2)
        {
            Hymir.enabled = false;
            Hymir2.enabled = true;
        }
        if (Textchange == 3)
        {
            Hymir2.enabled = false;
            Thor2.enabled = true;
        }
    }
}
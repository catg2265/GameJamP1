using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Cutscene5 : MonoBehaviour
{
    public int changer = 1;
    public Animator Sceneanimator;

    public int Textchange;

    public TextMeshProUGUI Hymir;
    public TextMeshProUGUI Jormungand;
    public TextMeshProUGUI Thor;

    // Start is called before the first frame update
    void Start()
    {
        Hymir.enabled = true;
        Jormungand.enabled = false;
        Thor.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Sceneanimator.SetInteger("Cutscenechange", changer++);
            Textchange++;
        }
        if (Input.GetButton("Jump")&& changer == 4)
        {
            SceneManager.LoadScene("cutscene6");
        }

        if (Textchange == 1)
        {
            Hymir.enabled = false;
            Jormungand.enabled = true;
        }

        if (Textchange == 2)
        {
            Jormungand.enabled = false;
            Thor.enabled = true;
        }
    }
}
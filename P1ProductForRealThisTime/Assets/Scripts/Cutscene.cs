using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Cutscene : MonoBehaviour
{
    private int changer = 1;
    public Animator Sceneanimator;
    public TextMeshProUGUI Thor;
    public TextMeshProUGUI Ægir;
    public TextMeshProUGUI Ran;
    public TextMeshProUGUI Thor2;

    public int Textchange;
    // Start is called before the first frame update
    void Start()
    {
        changer = 1;
        Thor.enabled = false;
        Ægir.enabled = false;
        Ran.enabled = false;
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
        if (Input.GetButton("Jump")&& changer == 7)
        {
            SceneManager.LoadScene("Main");
        }
        if (Textchange == 2)
        {
            Thor.enabled = true;
        }
        if (Textchange == 3)
        {
            Thor.enabled = false;
            Ægir.enabled = true;
        }
        if (Textchange == 4)
        {
            Ægir.enabled = false;
            Ran.enabled = true;
        }
        if (Textchange == 5)
        {
            Ran.enabled = false;
            Thor2.enabled = true;
        }

    }
}

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
    public TextMeshProUGUI Aegir;
    public TextMeshProUGUI Ran;
    public TextMeshProUGUI Thor2;
    public GameObject spacebar;

    public int Textchange;
    // Start is called before the first frame update
    void Start()
    {
        changer = 1;
        Thor.enabled = false;
        Aegir.enabled = false;
        Ran.enabled = false;
        Thor2.enabled = false;
        spacebar.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Sceneanimator.SetInteger("Cutscenechange", changer++);
            Textchange++;
            spacebar.SetActive(false);
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
            Aegir.enabled = true;
        }
        if (Textchange == 4)
        {
            Aegir.enabled = false;
            Ran.enabled = true;
        }
        if (Textchange == 5)
        {
            Ran.enabled = false;
            Thor2.enabled = true;
        }

    }
}

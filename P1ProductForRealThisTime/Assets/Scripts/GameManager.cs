using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region SceneChanges

    public void StartMain()
    {
        SceneManager.LoadScene("Main");
    }
    public void EndGame()
    {
        Application.Quit();
    }

    public void startcutscene1()
    {
        SceneManager.LoadScene("Cutscene1");
    }
    #endregion

    #region  Minigame

    [SerializeField] private GameObject ControlScreen;
    [SerializeField] private GameObject Minigame;
    [SerializeField] private GameObject Backgrounds;

    public bool UseGameObjects = true;
    
    private void Start()
    {
        if (UseGameObjects)
        {
            Minigame.SetActive(false);
            Backgrounds.SetActive(false);
            ControlScreen.SetActive(true);
        }
        else
        {
            ControlScreen = null;
            Minigame = null;
            Backgrounds = null;
        }
    }

    public void StartMinigame()
    {
        ControlScreen.SetActive(false);
        Backgrounds.SetActive(true);
        Minigame.SetActive(true);
    }

    #endregion
}

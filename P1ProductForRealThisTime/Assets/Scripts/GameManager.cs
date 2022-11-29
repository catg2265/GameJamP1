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
}

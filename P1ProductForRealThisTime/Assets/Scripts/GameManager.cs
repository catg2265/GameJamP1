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
    #endregion
}

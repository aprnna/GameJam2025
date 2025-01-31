using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Boss Battle Wolf");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}

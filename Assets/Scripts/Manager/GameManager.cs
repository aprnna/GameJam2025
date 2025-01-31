using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isGameOver = false;
    public bool isPaused = false;
    public GameObject pausePanel;
    public GameObject gameOverPanel;
    public Button buttonContinue;
    public Button buttonExit;

    public GameObject player;
    private Status playerStatus;

    void Start()
    {
        pausePanel.SetActive(false);

        player = GameObject.FindWithTag("player");
        playerStatus = player.GetComponent<Status>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) & !isGameOver)
        {
            PauseGame();
        }

        if(!isGameOver)
        {
            if(playerStatus.hitPoint <= 0)
            {
                isGameOver = true;
            }
        }

        if(isGameOver)
        {
            GameOver();
        }
    }

    public void PauseGame()
    {
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
        pausePanel.SetActive(isPaused);
        buttonContinue.interactable = isPaused;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(isGameOver);
    }

    public void NewGame()
    {
        Time.timeScale = 1;
    }

    public void ResumeGame()
    {
        PauseGame();
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("Main Menu - 2");
    }

    public void DestroyAllObjects()
    {
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            if (!obj.CompareTag("MainCamera")) 
            {
                Destroy(obj);
            }
        }
    }
}

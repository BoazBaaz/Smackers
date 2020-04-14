using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject startMenuUI;
    public GameObject pauseMenuUI;
    public GameObject winScreenUI;

    public bool inTitleScreen = true;
    public bool GameIsPaused = false;
    public bool inWinScreen = false;

    void Update()
    {
        if (!inTitleScreen)
        {
            if (!inWinScreen)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    if (GameIsPaused)
                    {
                        Resume();
                    }
                    else
                    {
                        Pause();
                    }
                }
            }
            else
            {
                Invoke("ReadKeyWorkAround", 2f);
            }
        }
    }
    public void StartGame()
    {
        startMenuUI.SetActive(false);
        inTitleScreen = false;
        Time.timeScale = 1f;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadMenu()
    {
        GameIsPaused = false;
        inWinScreen = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void WinScreen(GameObject deadplayer)
    {
        inWinScreen = true;

        winScreenUI.SetActive(true);
        Text text = winScreenUI.GetComponentInChildren<Text>();


        if (deadplayer.CompareTag("Player1"))
        {
            text.text = "Player 2 won!";
        }
        if (deadplayer.CompareTag("Player2"))
        {
            text.text = "Player 1 won!";
        }
    }

    private void ReadKeyWorkAround()
    {
        if (Input.anyKey)
        {
            LoadMenu();
        }
    }
}

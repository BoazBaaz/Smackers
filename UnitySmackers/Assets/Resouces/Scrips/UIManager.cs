using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject startMenuUI;
    public GameObject pauseMenuUI;

    public bool inTitleScreen = true;
    public bool GameIsPaused = false;

    void Update()
    {
        if (!inTitleScreen)
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}

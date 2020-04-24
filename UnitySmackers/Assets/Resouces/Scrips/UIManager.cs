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
    public GameObject optionMenuUI;
    public GameObject quitScreenUI;

    public bool inStartScreen = true;
    public bool inPauseScreen = false;
    public bool inWinScreen = false;
    public bool inOptionScreen = false;
    public bool inQuitScreen = false;
    public bool inGame = false;

    void Update()
    {
        if (inGame || inPauseScreen)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (inPauseScreen)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
        if (inWinScreen)
        {
            Invoke("ReadKeyWorkAround", 2f);

        }
        if (inStartScreen || inQuitScreen)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!inQuitScreen)
                {
                    FindObjectOfType<AudioManager>().Play("Click");

                    inQuitScreen = true;
                    inStartScreen = false;
                    quitScreenUI.SetActive(true);
                }
                else
                {
                    inQuitScreen = false;
                    inStartScreen = true;
                    quitScreenUI.SetActive(false);
                }
            }
        }

        if (!inStartScreen && !inOptionScreen && !inPauseScreen && !inWinScreen && !inQuitScreen)
        {
            inGame = true;
        }
        else
        {
            inGame = false;
        }
    }



    public void StartGame()
    {
        FindObjectOfType<AudioManager>().Play("Click");

        startMenuUI.SetActive(false);
        inStartScreen = false;
        Time.timeScale = 1f;
    }
    public void OptionButton()
    {
        FindObjectOfType<AudioManager>().Play("Click");

        inOptionScreen = true;
        inStartScreen = false;
        startMenuUI.SetActive(false);
        optionMenuUI.SetActive(true);
    }
    public void BackButton()
    {
        FindObjectOfType<AudioManager>().Play("Click");

        inStartScreen = true;
        inOptionScreen = false;
        inQuitScreen = false;
        quitScreenUI.SetActive(false);
        optionMenuUI.SetActive(false);
        startMenuUI.SetActive(true);
        Time.timeScale = 1f;
    }

    public void Resume()
    {
        FindObjectOfType<AudioManager>().Play("Click");

        inPauseScreen = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }
    void Pause()
    {
        FindObjectOfType<AudioManager>().Play("Click");

        inPauseScreen = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void LoadMenu()
    {
        FindObjectOfType<AudioManager>().Play("Click");

        inStartScreen = true;
        inPauseScreen = false;
        inWinScreen = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    public void QuitGame()
    {
        FindObjectOfType<AudioManager>().Play("Click");

        Debug.Log("Quitting game...");
        Application.Quit();
    }


    public void WinScreen(GameObject victoryPlayer)
    {
        inWinScreen = true;

        winScreenUI.SetActive(true);

        Text text = winScreenUI.GetComponentInChildren<Text>();

        text.text = victoryPlayer.name + " won!";
    }

    private void ReadKeyWorkAround()
    {
        if (Input.anyKey)
        {
            LoadMenu();
        }
    }
}

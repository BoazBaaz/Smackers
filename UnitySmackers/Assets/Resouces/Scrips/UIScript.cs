using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }

    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneSwitch : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }

    public void SetScene(int sceneInput)
    {
        SceneManager.LoadScene(sceneInput);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startmenu : MonoBehaviour
{
    public bool inTitleScreen = true;

    public GameObject startMenuUI;

    public void StartGame()
    {
        startMenuUI.SetActive(false);
        inTitleScreen = false;
        Time.timeScale = 1f;
        Debug.Log("button is ingedrukt");

    }
}    


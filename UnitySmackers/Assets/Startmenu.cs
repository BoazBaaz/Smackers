using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startmenu : MonoBehaviour
{
    public static bool GameStart = true;

    public GameObject startMenuUI;

    public void StartGame()
    {
        startMenuUI.SetActive(false);
        GameStart = false;
        Debug.Log("button is ingedrukt");

    }
}    


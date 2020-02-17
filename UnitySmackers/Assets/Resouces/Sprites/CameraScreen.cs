using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScreen : MonoBehaviour
{
    public GameObject m_Player1;
    public GameObject m_Player2;

    void Start()
    {
        m_Player1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<GameObject>();
        m_Player2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

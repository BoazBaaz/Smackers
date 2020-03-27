﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float m_MaxHealth = 100f;
    public float m_CurrentHealth;

    public float m_Damage = 10f;

    private void Start()
    {
        m_CurrentHealth = m_MaxHealth;
    }

    private void Update()
    {
        if (m_CurrentHealth <= 0)
        {
            Debug.Log("U dead MATE!!!" + gameObject.name);
        }
    }

    //Maby Headshots more damage later???

    public void GetHit()
    {
        m_CurrentHealth -= m_Damage;
    }
}

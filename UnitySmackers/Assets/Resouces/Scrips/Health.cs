using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Health : PlayerCore
{
    private void Start()
    {
        m_CurrentHealth = m_MaxHealth;
    }

    private void Update()
    {
        if (m_CurrentHealth <= 0)
        {
            playerDied = true;
            Die();
        }
    }

    public void Die()
    {
        AnimControlScript.SetRigidbodyState(false);
        AnimControlScript.SetColliderState(true);
    }

    public void GetHit()
    {
        m_CurrentHealth -= m_Damage;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player1") || other.gameObject.CompareTag("Player2"))
        {
            if (actionKeyBool)
            {
                Health targetMind = other.gameObject.GetComponentInParent<Health>();
                targetMind.GetHit();
                actionKeyBool = false;
            }
        }
    }
}

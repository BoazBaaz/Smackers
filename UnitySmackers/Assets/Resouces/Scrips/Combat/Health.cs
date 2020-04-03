using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Health : MonoBehaviour
{
    private AnimationController animContr;

    public float m_MaxHealth = 100f;
    public float m_CurrentHealth;

    public float m_Damage = 10f;

    public bool playerDied = false;

    public bool actionSend;

    private void Start()
    {
        animContr = gameObject.GetComponent<AnimationController>();
        m_CurrentHealth = m_MaxHealth;
    }

    private void Update()
    {
        if (m_CurrentHealth <= 0)
        {
            playerDied = true;
            animContr.Die();
        }
    }

    public void Die()
    {
        animContr.anim.enabled = false;
        animContr.SetRigidbodyState(false);
        animContr.SetColliderState(true);

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GetHit()
    {
        m_CurrentHealth -= m_Damage;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player1") || other.gameObject.CompareTag("Player2"))
        {
            if (actionSend)
            {
                Health targetMind = other.gameObject.GetComponentInParent<Health>();
                targetMind.GetHit();
                actionSend = false;
            }
        }
    }
}

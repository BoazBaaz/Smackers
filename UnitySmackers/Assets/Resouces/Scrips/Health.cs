using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Health : PlayerCore
{
    private UIManager UIManagerScript;


    [Header("Health")]
    public float m_MaxHealth = 100f;
    public float m_CurrentHealth;

    public float m_Damage = 10f;

    [Header("Death")]
    public bool playerDied = false;
    private bool playerDiedTrigger = false;

    public int minForceOnDeath = 400;
    public int maxForceOnDeath = 500;
    public int forceX;


    private void Start()
    {
        UIManagerScript = GameObject.FindGameObjectWithTag("Canvas").GetComponent<UIManager>();
        m_CurrentHealth = m_MaxHealth;
    }

    private void Update()
    {
        if (m_CurrentHealth <= 0 && !playerDiedTrigger)
        {
            playerDied = true;
            Die();
            playerDiedTrigger = true;
        }
    }

    public void Die()
    {
        AnimControlScript.SetRigidbodyState(false);
        AnimControlScript.SetColliderState(true);

        Rigidbody[] rigidbodys = gameObject.GetComponentsInChildren<Rigidbody>();

        int random = Random.Range(0, rigidbodys.Length);
        int force = Random.Range(minForceOnDeath, maxForceOnDeath);
        forceX = force;

        Vector3 backward = Quaternion.identity * Vector3.back;

        rigidbodys[random].AddForce((transform.position + backward) * force, ForceMode.Impulse);

        UIManagerScript.WinScreen(gameObject);
    }

    public void GetHit()
    {
        m_CurrentHealth -= m_Damage;
    }

    public void HitEnemy(Collider other)
    {
        if (PlayerMovementScript.actionKeyPressed)
        {
            Health targetMind = other.gameObject.GetComponentInParent<Health>();
            targetMind.GetHit();
            PlayerMovementScript.actionKeyPressed = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player1") || other.gameObject.CompareTag("Player2"))
        {
            HitEnemy(other);
        }
    }
}

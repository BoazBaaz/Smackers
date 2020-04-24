using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Health : PlayerCore
{
    private UIManager UIManagerScript;
    private Material mat;

    [Header("Health")]
    public float m_MaxHealth = 100f;
    public float m_CurrentHealth;
    private float stage = 0f;

    public float m_Damage = 10f;

    [Header("Death")]
    public bool playerDied = false;

    [Header("Force")]
    public int minForceOnDeath = 400;
    public int maxForceOnDeath = 500;
    public int forceX;


    private void Start()
    {
        UIManagerScript = GameObject.FindGameObjectWithTag("Canvas").GetComponent<UIManager>();
        m_CurrentHealth = m_MaxHealth;

        mat = GetComponentInChildren<Renderer>().material;
    }

    public void Die(GameObject other)
    {
        AnimControlScript.SetRigidbodyState(false);
        AnimControlScript.SetColliderState(true);

        Rigidbody[] rigidbodys = gameObject.GetComponentsInChildren<Rigidbody>();

        int random = Random.Range(0, rigidbodys.Length);
        int force = Random.Range(minForceOnDeath, maxForceOnDeath);
        forceX = force;

        Vector3 backward = Quaternion.identity * Vector3.forward;

        rigidbodys[random].AddForce((transform.position + backward) * force, ForceMode.Impulse);

        other.GetComponent<AnimationController>().SetRigidbodyState(true);

        UIManagerScript.WinScreen(other);
    }

    public void GetHit(GameObject other)
    {
        m_CurrentHealth -= m_Damage;
        stage += 0.1f;

        FindObjectOfType<AudioManager>().Play("Punch");

        mat.color = Color.Lerp(mat.color, Color.white, stage);

        if (m_CurrentHealth <= 0 && !playerDied)
        {
            playerDied = true;
            Die(other);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player1") || other.gameObject.CompareTag("Player2"))
        {
            if (PlayerMovementScript.actionKeyPressed)
            {
                Health targetMind = other.gameObject.GetComponentInParent<Health>();
                targetMind.GetHit(gameObject);

                PlayerMovementScript.actionKeyPressed = false;
            }
        }
    }
}

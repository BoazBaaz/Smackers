using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Health : MonoBehaviour
{
    public Canvas canvas;
    public Text text;

    public Rigidbody playerRigidbody;
    public Rigidbody targetRigidbody;

    public LayerMask layerMask;

    public float raycastRange = 10f;

    public float HitForce;

    public int maxHealth = 100;
    public int currentHealth;

    public int damage = 10;

    void Start()
    {
        currentHealth = maxHealth;
    }
    private void Update()
    {
        if (RaycastEnemy())
            Hit();

        if (currentHealth > 0)
            EndMatch();
    }

    private bool RaycastEnemy()
    {
        Vector3 directionToTarget = (targetRigidbody.position - playerRigidbody.position).normalized;

        bool isHit = Physics.Raycast(playerRigidbody.position, directionToTarget, raycastRange, layerMask);

        Debug.DrawRay(playerRigidbody.position, directionToTarget * raycastRange, Color.red);

        if (isHit)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                return true;
            }
        }

        return false;
    }

    private void Hit()
    {
        targetRigidbody.SendMessage("GetHit", damage);
    }

    private void GetHit(int damage)
    {
        currentHealth -= damage;
    }

    private void EndMatch()
    {
        Time.timeScale = 0f;

        text.text = gameObject.name + " won.";
        canvas.enabled = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCore : MonoBehaviour
{
    [Header("Scripts")]

    public Health healthScript;
    public AnimationController AnimControlScript;
    public PlayerMovement PlayerMovementScript;

    [Header("Input")]
    public float moveSpeed = 20f;
    public float smoothSpeed = 1f;

    public Vector3 vectorInput;
    public Vector3 lastMovement;

    public KeyCode ActionKey;
    protected bool actionKeyBool;

    [Header("Health")]

    public float m_MaxHealth = 100f;
    public float m_CurrentHealth;

    public float m_Damage = 10f;

    public bool playerDied = false;

    private void Start()
    {
        healthScript = gameObject.GetComponent<Health>();
        AnimControlScript = gameObject.GetComponent<AnimationController>();
        PlayerMovementScript = gameObject.GetComponent<PlayerMovement>();
    }
}

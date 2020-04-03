using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator anim;

    protected Health healthScript;
    protected PlayerMovement playerMovementScript;

    private void Start()
    {
        healthScript = gameObject.GetComponent<Health>();
        playerMovementScript = gameObject.GetComponent<PlayerMovement>();

        SetRigidbodyState(true);
        SetColliderState(false);
    }

    private void Update()
    {
        AnimatorSwitches();
    }

    public void Die()
    {
        anim.enabled = false;
        SetRigidbodyState(false);
        SetColliderState(true);
        
    }

    public void SetRigidbodyState(bool state)
    {
        Rigidbody[] rigidbodys = gameObject.GetComponentsInChildren<Rigidbody>();

        foreach (Rigidbody rigidbody in rigidbodys)
        {
            rigidbody.isKinematic = state;
        }

        GetComponent<Rigidbody>().isKinematic = !state;
    }

    public void SetColliderState(bool state)
    {
        Collider[] colliders = gameObject.GetComponentsInChildren<Collider>();

        foreach (Collider collider in colliders)
        {
            collider.enabled = state;
        }

        Collider[] colliderOnObject = gameObject.GetComponents<Collider>();

        foreach (Collider collider in colliderOnObject)
        {
            collider.enabled = !state;
        }
    }

    private void AnimatorSwitches()
    {
        if (healthScript.playerDied)
        {
            anim.SetTrigger("Died");
            Die();
        }

        if (playerMovementScript.actionKey)
        {
            healthScript.actionSend = true;

            anim.SetTrigger("ActionPressed"); //On
            anim.SetTrigger("ActionPressed"); //Off

            playerMovementScript.actionKey = false;
        }

        if (playerMovementScript.vectorInput != Vector3.zero)
        {
            anim.SetBool("Moving", true);

            playerMovementScript.lastMovement = playerMovementScript.vectorInput;
        }
        else
        {
            anim.SetBool("Moving", false);
        }
    }
}

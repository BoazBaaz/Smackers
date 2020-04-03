using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : PlayerCore
{

    private void Start()
    {
        SetRigidbodyState(true);
        SetColliderState(false);
    }

    private void Update()
    {
        AnimatorSwitches();
    }

    public void Die()
    {
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
            animator.SetTrigger("Died");
            Die();
        }

        if (actionKeyBool)
        {
            animator.SetTrigger("ActionPressed"); //On
            animator.SetTrigger("ActionPressed"); //Off

            actionKeyBool = false;
        }

        if (vectorInput != Vector3.zero)
        {
            animator.SetBool("Moving", true);

            lastMovement = vectorInput;
        }
        else
        {
            animator.SetBool("Moving", false);
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : PlayerCore
{
    public Animator animator;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();

        SetRigidbodyState(true);
        SetColliderState(false);
    }

    private void Update()
    {
        AnimatorSwitches();
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
        if (playerDied)
        {
            animator.SetTrigger("Died");
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

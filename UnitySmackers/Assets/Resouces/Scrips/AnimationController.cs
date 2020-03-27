using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Rigidbody[] playerRBS;
    public Animator anim;

    private Health healthScript;
    private PlayerMovement playerMovementScript;

    private void Start()
    {
        healthScript = gameObject.GetComponent<Health>();
        playerMovementScript = gameObject.GetComponent<PlayerMovement>();


        playerRBS = gameObject.GetComponentsInChildren<Rigidbody>();

        for (int i = 0; i < playerRBS.Length; i++)
        {
            playerRBS[i].isKinematic = true;
        }
    }

    private void Update()
    {
        if (healthScript.playerDied == true)
        {
            anim.SetTrigger("Died");
            for (int i = 0; i < playerRBS.Length; i++)
            {
                playerRBS[i].isKinematic = false;
            }
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

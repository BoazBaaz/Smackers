using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class PlayerCore : NetworkBehaviour
{
    [Header("Scripts")]
    public Health healthScript;
    public AnimationController AnimControlScript;
    public PlayerMovement PlayerMovementScript;


    private void Start()
    {
        healthScript = gameObject.GetComponent<Health>();
        AnimControlScript = gameObject.GetComponent<AnimationController>();
        PlayerMovementScript = gameObject.GetComponent<PlayerMovement>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatCollider : Health
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BodyCollider"))
        {
            Health targetMind = other.gameObject.GetComponentInParent<Health>();
            targetMind.GetHit();
        }
        else if (other.gameObject.CompareTag("CombatCollider"))
        {

        }
    }
}

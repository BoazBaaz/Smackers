using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 20;

    private Vector3 vectorInput;

    private void Update()
    {
        if (gameObject.CompareTag("Player2"))
        {
            vectorInput.x = Input.GetAxis("Horizontal2");
            vectorInput.z = Input.GetAxis("Vertical2");
        }
        if (gameObject.CompareTag("Player1"))
        {
            vectorInput.x = Input.GetAxis("Horizontal1");
            vectorInput.z = Input.GetAxis("Vertical1");
        }
    }

    private void FixedUpdate()
    {
        transform.position += ((vectorInput * moveSpeed) * Time.fixedDeltaTime);
    }
}

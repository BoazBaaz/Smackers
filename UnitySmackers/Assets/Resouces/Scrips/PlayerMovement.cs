using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 20f;
    public float smoothSpeed = 1f;

    public Vector3 vectorInput;
    public Vector3 lastMovement;

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
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lastMovement), smoothSpeed);

        transform.Translate(vectorInput * moveSpeed * Time.deltaTime, Space.World);
    }
}

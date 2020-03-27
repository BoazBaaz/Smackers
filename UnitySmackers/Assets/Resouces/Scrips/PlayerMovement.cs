using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rigidbodyPlayer;
    public float moveSpeed = 20;

    private Vector3 vectorInput;

    private void FixedUpdate()
    {
        if (rigidbodyPlayer.CompareTag("Player2"))
        {
            vectorInput.x = Input.GetAxis("Horizontal2");
            vectorInput.z = Input.GetAxis("Vertical2");

            Vector3 newPos = rigidbodyPlayer.position + ((vectorInput * moveSpeed) * Time.fixedDeltaTime);

            rigidbodyPlayer.MovePosition(newPos);
        }
        if (rigidbodyPlayer.CompareTag("Player1"))
        {
            vectorInput.x = Input.GetAxis("Horizontal1");
            vectorInput.z = Input.GetAxis("Vertical1");

            Vector3 newPos = rigidbodyPlayer.position + ((vectorInput * moveSpeed) * Time.fixedDeltaTime);

            rigidbodyPlayer.MovePosition(newPos);
        }
    }
}

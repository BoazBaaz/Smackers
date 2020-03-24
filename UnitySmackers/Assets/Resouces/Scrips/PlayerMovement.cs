using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public KeyCode left;
    //public KeyCode right;
    //public KeyCode forward;
    //public KeyCode Backward;

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

    private void Update()
    {
        #region Old Code
        //if (Input.GetKey(left))
        //{
        //    transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        //}
        //if (Input.GetKey(right))
        //{
        //    transform.position += Vector3.right * moveSpeed * Time.deltaTime;

        //}
        //if (Input.GetKey(forward))
        //{
        //    transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        //}
        //else if (Input.GetKey(Backward))
        //{
        //    transform.position += Vector3.back * moveSpeed * Time.deltaTime;
        //}
        #endregion
    }
}

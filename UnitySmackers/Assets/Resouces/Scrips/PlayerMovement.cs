using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    public KeyCode left;
    public KeyCode right;
    public KeyCode forward;
    public KeyCode Backward;

    private void Update()
    {
        if (Input.GetKey(left))
        {
            transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(right))
        {
            transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            
        }
        if (Input.GetKey(forward))
        {
            transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(Backward))
        {
            transform.position += Vector3.back * moveSpeed * Time.deltaTime;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : PlayerCore
{
    private UIManager UIManagerScript;

    [Header("Input")]
    public Vector3 vectorInput;
    public Vector3 lastMovement;

    public float moveSpeed = 20f;
    public float smoothSpeed = 1f;

    public bool actionKeyPressed = false;


    private void Start()
    {
        UIManagerScript = GameObject.FindGameObjectWithTag("Canvas").GetComponent<UIManager>();
    }

    private void Update()
    {

        if (!UIManagerScript.inTitleScreen)
        {
            if (!healthScript.playerDied)
            {
                if (gameObject.CompareTag("Player2"))
                {
                    vectorInput.x = Input.GetAxis("Horizontal2");
                    vectorInput.z = Input.GetAxis("Vertical2");

                    if (Input.GetKeyDown(KeyCode.RightControl))
                    {
                        actionKeyPressed = true;
                    }
                }
                if (gameObject.CompareTag("Player1"))
                {
                    vectorInput.x = Input.GetAxis("Horizontal1");
                    vectorInput.z = Input.GetAxis("Vertical1");

                    if (Input.GetKeyDown(KeyCode.LeftShift))
                    {
                        actionKeyPressed = true;
                    }
                }

            }
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lastMovement), smoothSpeed);

        transform.Translate(vectorInput * moveSpeed * Time.deltaTime, Space.World);
    }
}

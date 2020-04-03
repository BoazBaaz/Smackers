using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Startmenu startMenuScript;

    public float moveSpeed = 20f;
    public float smoothSpeed = 1f;

    public Vector3 vectorInput;
    public Vector3 lastMovement;

    public bool actionKey;


    private void Start()
    {
        startMenuScript = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Startmenu>();
    }

    private void Update()
    {

        if (!startMenuScript.inTitleScreen)
        {
            if (gameObject.CompareTag("Player2"))
            {
                vectorInput.x = Input.GetAxis("Horizontal2");
                vectorInput.z = Input.GetAxis("Vertical2");

                if (Input.GetKeyDown(KeyCode.RightControl))
                {
                    actionKey = true;
                }
            }
            if (gameObject.CompareTag("Player1"))
            {
                vectorInput.x = Input.GetAxis("Horizontal1");
                vectorInput.z = Input.GetAxis("Vertical1");

                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    actionKey = true;
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

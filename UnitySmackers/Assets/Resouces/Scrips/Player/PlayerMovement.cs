using Mirror;
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

    [Client]
    private void Start()
    {
        UIManagerScript = GameObject.FindGameObjectWithTag("Canvas").GetComponent<UIManager>();
    }


    private void Update()
    {
        if (!UIManagerScript.inStartScreen)
        {
            if (!healthScript.playerDied)
            {
                if (!hasAuthority)
                    return;

                vectorInput.x = Input.GetAxis("Horizontal1");
                vectorInput.z = Input.GetAxis("Vertical1");

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    actionKeyPressed = true;
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

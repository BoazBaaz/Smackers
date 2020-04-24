using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScreen : MonoBehaviour
{
    public Transform pl1;
    public Transform pl2;
    private Camera cam;

    public Canvas canves;
    public Health player1;
    public Health player2;
    private UIManager UIManagerScript;

    public Vector3 camStartPos;
    private Quaternion camStartRoto;

    public float cameraRotationSpeed = 10;

    public float zoomFactor = 1.5f;
    public float followTimeDelta = 0.8f;

    void Start()
    {
        camStartPos = transform.position;
        camStartRoto = transform.rotation;

        cam = gameObject.GetComponent<Camera>();
        UIManagerScript = canves.GetComponentInChildren<UIManager>();
    }

    private void FixedUpdate()
    {
        if (!UIManagerScript.inStartScreen)
        {
            if (player1.playerDied || player2.playerDied)
            {
                
            }
            else
            {
                transform.position = camStartPos;
                transform.rotation = camStartRoto;

                Vector3 midpoint = (pl1.position + pl2.position) / 2f;

                float distance = (pl1.position - pl2.position).magnitude;

                Vector3 cameraDestination = midpoint - cam.transform.forward * distance * zoomFactor;

                cam.transform.position = Vector3.Slerp(transform.position, cameraDestination, followTimeDelta);
            }
        }
        else
        {
            transform.RotateAround(Vector3.zero, Vector3.up, cameraRotationSpeed * Time.deltaTime);

            transform.LookAt(Vector3.zero);
        }
    }
}

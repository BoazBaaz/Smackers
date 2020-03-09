using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScreen : MonoBehaviour
{
    public Transform pl1;
    public Transform pl2;
    private Camera cam;

    public GameObject OppositeCamera;

    //public float rotationSpeed;

    public float zoomFactor = 1.5f;
    public float followTimeDelta = 0.8f;

    void Start()
    {
        cam = gameObject.GetComponent<Camera>();
    }

    private void FixedUpdate()
    {

        Vector3 midpoint = (pl1.position + pl2.position) / 2f;

        float distance = (pl1.position - pl2.position).magnitude;

        Vector3 cameraDestination = midpoint - cam.transform.forward * distance * zoomFactor;

        Vector3 midpointForward = midpoint - cam.transform.position;

        OppositeCamera.transform.position = midpointForward;

        cam.transform.position = Vector3.Slerp(cam.transform.position, cameraDestination, followTimeDelta);

        cam.transform.LookAt(midpointForward);

        //transform.RotateAround(midpoint, new Vector3(0f, 1f, 0f), 0.1f * rotationSpeed * Time.deltaTime);
    }
}

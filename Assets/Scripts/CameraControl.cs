using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Vector3 offset;
    public float zoomSpeed;
    public float maxFov;
    public float minFov;

    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        // This is not right
        Vector3 newPosition = playerTransform.position + offset;
        transform.position = Vector3.Lerp(transform.position, newPosition, 0.5f);

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        float newFov = Camera.main.fieldOfView - scroll * zoomSpeed;
        Camera.main.fieldOfView = Math.Clamp(newFov, minFov, maxFov);
    }
}

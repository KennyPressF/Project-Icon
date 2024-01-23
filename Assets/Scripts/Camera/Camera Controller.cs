using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomLerp : MonoBehaviour
{
    public float cameraClose = 3f; // First target orthographic size
    public float cameraMid = 5.5f; // First target orthographic size
    public float cameraFar = 8f; // Second target orthographic size
    public float zoomSpeed = 2.0f; // Speed of the zoom

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        // Check for input or trigger to start zooming
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Start the zooming coroutine
            StartCoroutine(ZoomToTarget(cameraMid));
        }
    }



    IEnumerator ZoomToTarget(float targetSize)
    {
        float elapsedTime = 0f;
        float startingSize = mainCamera.orthographicSize;

        while (elapsedTime < 1f)
        {
            mainCamera.orthographicSize = Mathf.Lerp(startingSize, targetSize, elapsedTime);
            elapsedTime += Time.deltaTime * zoomSpeed;

            yield return null;
        }

        // Ensure the camera reaches the exact target orthographic size
        mainCamera.orthographicSize = targetSize;
    }
}

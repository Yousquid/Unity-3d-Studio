using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamearRotationBasedonMouse : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the screen
    }

    void Update()
    {
        // Get mouse movement input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Rotate the player (left/right) - Y axis rotation
        transform.Rotate(Vector3.up * mouseX);

        // Rotate the camera (up/down) - X axis rotation, with clamping
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Prevent flipping over

        this.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}

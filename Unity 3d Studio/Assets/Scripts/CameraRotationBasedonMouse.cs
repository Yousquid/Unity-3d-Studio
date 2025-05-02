using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotationBasedonMouse : MonoBehaviour
{
    public float mouseXSensitivity = 100f;
    public float mouseYSensitivity = 100f;
    public Transform orientation;

    private float xRotation = 0f;
    private float yRotation = 0f;

    private bool hasStartedGame = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (hasStartedGame && MoveCamera.hasTransitioned)
        {
            //get mouse input
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * mouseYSensitivity;
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * mouseXSensitivity;

            yRotation += mouseX;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }

        
        
    }

    public void LockMouse()
    {
        Cursor.lockState = CursorLockMode.Locked; // Hide and lock cursor
        Cursor.visible = false;
        hasStartedGame = true;
    }
}

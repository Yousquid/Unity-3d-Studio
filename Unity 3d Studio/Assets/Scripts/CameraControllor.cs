using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllor : MonoBehaviour
{
    public GameObject topviewCamer;
    public static bool isUsingTopviewCamera = false;
    public float leastCameraDuration = 0.5f;
    public float leastCameraTimer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CameraControllor.isUsingTopviewCamera)
        {
            UseTopviewCamera();

           
        }
    }

    private void LateUpdate()
    {
        if (CameraControllor.isUsingTopviewCamera)
        {
            leastCameraTimer += Time.deltaTime;

            if (Input.anyKeyDown && topviewCamer.activeInHierarchy == true && leastCameraTimer >= leastCameraDuration)
            {
                TopviewCamera.isUsingTopviewCamera = false;
                StopUsingTopviewCamera();
                leastCameraTimer = 0;
                CameraControllor.isUsingTopviewCamera = false;
            }
        }
    }


    public void UseTopviewCamera()
    {
        topviewCamer.SetActive(true);
        
    }

    public void StopUsingTopviewCamera()
    {
        topviewCamer.SetActive(false);

    }
}

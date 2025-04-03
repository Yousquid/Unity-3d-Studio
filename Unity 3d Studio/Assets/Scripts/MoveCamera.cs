using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPos;
    public Transform childCameraPos;
    // Start is called before the first frame update
    void Start()
    {
        ResetChildCameraPosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (!CameraControllor.isUsingTopviewCamera)
        {
            Vector3 cameraTruePos = cameraPos.position + new Vector3(0, 2f, 0f);

            childCameraPos.position = cameraPos.position;
        }
        
    }

    void ResetChildCameraPosition()
    {
        childCameraPos.position = new Vector3(0, 0, 0);
        childCameraPos.rotation = Quaternion.Euler(0,0,0);
    }
}

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
    public Camera maincamera;
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
        AddLayerToCameraCulling(maincamera, "PlayerBody");
    }

    public void StopUsingTopviewCamera()
    {
        topviewCamer.SetActive(false);
        RemoveLayerFromCameraCulling(maincamera, "PlayerBody");
    }

    void AddLayerToCameraCulling(Camera cam, string layerName)
    {
        int layer = LayerMask.NameToLayer(layerName);
        if (layer < 0)
        {
            Debug.LogWarning("Layer not found: " + layerName);
            return;
        }

        // 用位运算将该层加入到cullingMask中
        cam.cullingMask |= (1 << layer);
    }

    void RemoveLayerFromCameraCulling(Camera cam, string layerName)
    {
        int layer = LayerMask.NameToLayer(layerName);
        if (layer < 0)
        {
            Debug.LogWarning("Layer not found: " + layerName);
            return;
        }

        // 用位运算将该层从cullingMask中移除
        cam.cullingMask &= ~(1 << layer);
    }
}

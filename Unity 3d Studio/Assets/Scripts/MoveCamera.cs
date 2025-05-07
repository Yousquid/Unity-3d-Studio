using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPos;           // ��һ�˳Ƶ�Ŀ��λ��
    public Transform childCameraPos;      // ʵ�������λ��
    public Transform introCameraPos;      // ��ʼ�߿��ӽ�λ��
    public Vector3 fixedRotationEuler; // �� Inspector ����������Ҫ�Ĺ̶��Ƕ�
    private Quaternion fixedRotation;

    public float transitionDuration = 2f; // ��ͷ����ʱ��
    private float transitionTimer = 0f;

    private bool isTransitioning = false;
    public static bool hasTransitioned = false;
    public Camera maincamera;

    void Start()
    {
        // ���ó�ʼ�����λ��Ϊ�߿ո����ӽ�
        fixedRotation = Quaternion.Euler(fixedRotationEuler);
        childCameraPos.position = introCameraPos.position;
        childCameraPos.rotation = fixedRotation;
    }

    void Update()
    {
        // �����ʼ��Ϸ��������滻Ϊ��ť�¼���


        if (isTransitioning)
        {
            transitionTimer += Time.deltaTime;
            float t = transitionTimer / transitionDuration;
            t = Mathf.SmoothStep(0, 1, t); // ƽ����ֵ

            // ��ֵλ�ã�����ֵ�Ƕ�
            childCameraPos.position = Vector3.Lerp(introCameraPos.position, cameraPos.position, t);
            childCameraPos.rotation = fixedRotation;

            if (t >= 1f)
            {
                isTransitioning = false;

                hasTransitioned = true;

                RemoveLayerFromCameraCulling(maincamera, "PlayerBody");
            }
        }
        else if (hasTransitioned && !CameraControllor.isUsingTopviewCamera)
        {
            childCameraPos.position = cameraPos.position;
            //childCameraPos.rotation = fixedRotation;
        }
    }

    public void OnClickStartCameraMove()
    {
        
            isTransitioning = true;
            transitionTimer = 0f;
        
    }

    void RemoveLayerFromCameraCulling(Camera cam, string layerName)
    {
        int layer = LayerMask.NameToLayer(layerName);
        if (layer < 0)
        {
            Debug.LogWarning("Layer not found: " + layerName);
            return;
        }

        // ��λ���㽫�ò��cullingMask���Ƴ�
        cam.cullingMask &= ~(1 << layer);
    }
}

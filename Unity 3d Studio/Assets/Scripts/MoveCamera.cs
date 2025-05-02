using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPos;           // 第一人称的目标位置
    public Transform childCameraPos;      // 实际摄像机位置
    public Transform introCameraPos;      // 初始高空视角位置
    public Vector3 fixedRotationEuler; // 在 Inspector 中设置你想要的固定角度
    private Quaternion fixedRotation;

    public float transitionDuration = 2f; // 镜头过渡时间
    private float transitionTimer = 0f;

    private bool isTransitioning = false;
    public static bool hasTransitioned = false;

    void Start()
    {
        // 设置初始摄像机位置为高空俯拍视角
        fixedRotation = Quaternion.Euler(fixedRotationEuler);
        childCameraPos.position = introCameraPos.position;
        childCameraPos.rotation = fixedRotation;
    }

    void Update()
    {
        // 点击开始游戏（你可以替换为按钮事件）


        if (isTransitioning)
        {
            transitionTimer += Time.deltaTime;
            float t = transitionTimer / transitionDuration;
            t = Mathf.SmoothStep(0, 1, t); // 平滑插值

            // 插值位置，不插值角度
            childCameraPos.position = Vector3.Lerp(introCameraPos.position, cameraPos.position, t);
            childCameraPos.rotation = fixedRotation;

            if (t >= 1f)
            {
                isTransitioning = false;
                hasTransitioned = true;
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
}

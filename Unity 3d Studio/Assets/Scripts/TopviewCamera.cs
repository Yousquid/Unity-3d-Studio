using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopviewCamera : MonoBehaviour
{
    public Transform playerPos;
    private Vector3 targetPos;
    private float duration = 2f;
    private float elapsedTime = 0f;
    private bool isMoving = false;
    public static bool isUsingTopviewCamera;

    void Start()
    {
        
    }
    

     void StartCameraMove()
    {
        this.transform.position = playerPos.position;
        targetPos = playerPos.position + new Vector3(1f, 19f, -7f);
        elapsedTime = 0f;
        isMoving = true;
        TopviewCamera.isUsingTopviewCamera = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration; // 计算归一化时间（0~1）

            // 平滑插值
            this.transform.position = Vector3.Lerp(transform.position, targetPos, t);

            // 结束条件
            if (elapsedTime >= duration)
            {
                transform.position = targetPos;
                isMoving = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.K))
        { 
            StartCameraMove();
        }

        if (TopviewCamera.isUsingTopviewCamera)
        {
            StartCameraMove();
        }
    }
}

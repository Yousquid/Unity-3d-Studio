using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavObject : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    public float waitTime = 0.1f;

    private NavMeshAgent agent;
    private Vector3 targetPos;
    private float waitTimer = 0f;
    private bool waiting = false;
    private bool goingToA = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        targetPos = pointB.position;
        agent.SetDestination(targetPos);
    }

    void Update()
    {
        if (waiting)
        {
            waitTimer += Time.deltaTime;
            if (waitTimer >= waitTime)
            {
                waiting = false;
                JumpToTarget(); // ִ����Ծ��˲�ƣ�
            }
            return;
        }

        if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            // ����Ŀ����ʼ�ȴ�
            waitTimer = 0f;
            waiting = true;
        }
    }

    void JumpToTarget()
    {
        goingToA = !goingToA;
        targetPos = goingToA ? pointA.position : pointB.position;

        agent.enabled = false;
        transform.position = targetPos; // ˲����Ծ��ȥ
        agent.enabled = true;

        agent.SetDestination(targetPos == pointA.position ? pointB.position : pointA.position);
    }
}

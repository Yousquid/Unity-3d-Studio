using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointManager : MonoBehaviour
{
    public List<Transform> savePoints; // �浵���б�
    public int currentIndex = 0;

    public Transform GetCurrentSavePoint() => savePoints[currentIndex];
    public Transform GetNextSavePoint() =>
        currentIndex + 1 < savePoints.Count ? savePoints[currentIndex + 1] : null;
}

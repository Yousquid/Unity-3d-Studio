using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI checkpointTextRemind;
    public TextMeshProUGUI checkpointCheckRemind;
    public bool IsCheckpoint = false;

    public bool IsChecking = false;
    private float checkTimer = 0;
    private float checkTotal = 1f;

    private void Update()
    {
        CheckpointUI();
    }


    void CheckpointUI()
    {
        if (IsCheckpoint)
        {
            checkpointTextRemind.enabled = true;
        }
        else
        {
            checkpointTextRemind.enabled = false;
        }

        CheckTextUI();
    }

    void CheckTextUI()
    {
        if (IsChecking)
        { 
            checkpointCheckRemind.enabled = true;
            checkTimer += Time.deltaTime;
        }

        if (checkTimer >= checkTotal)
        {
            checkpointCheckRemind.enabled = false;
            IsChecking = false ;
            checkTimer = 0;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI checkpointTextRemind;
    public TextMeshProUGUI checkpointCheckRemind;
    static bool IsCheckpointRemind = false;

    private void Update()
    {
        CheckpointUI();
    }


    void CheckpointUI()
    {
        if (IsCheckpointRemind)
        {
            checkpointTextRemind.enabled = true;
        }
        else
        {
            checkpointTextRemind.enabled = false;
        }

        if (IsCheckpointRemind && Input.GetKeyDown(KeyCode.E))
        { 
        
        }
    }
}

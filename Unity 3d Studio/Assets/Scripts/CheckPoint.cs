using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public BoxCollider checkpointTriggerCollider;
    public UIManager UImanager;

    // Start is called before the first frame update
    void Start()
    {
        checkpointTriggerCollider = GetComponent<BoxCollider>();
        UImanager = GameObject.FindGameObjectWithTag("Manager").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            UImanager.IsCheckpoint = true;

            if (Input.GetKeyDown(KeyCode.E))
            { 
                PlayerRespawn playerRespawn = other.GetComponent<PlayerRespawn>();
                playerRespawn.SetCheckpoint(other.transform.position);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            UImanager.IsCheckpoint = false;
        }
    }
}

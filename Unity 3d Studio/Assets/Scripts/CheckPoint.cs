using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public BoxCollider checkpointTriggerCollider;

    // Start is called before the first frame update
    void Start()
    {
        checkpointTriggerCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        { 
            
        }
    }
}

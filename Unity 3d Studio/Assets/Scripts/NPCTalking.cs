using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTalking : MonoBehaviour
{
    public string talkingWords;
    public BoxCollider thisCollider;

    private void Start()
    {
        thisCollider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        { 
            
        }
    }
}

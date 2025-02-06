using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public FirstPersonController playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Soul")
        {
            playerMovement.jumpCount -= 1;;
        }
    }
}

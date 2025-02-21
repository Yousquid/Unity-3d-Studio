using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerRigidbodyBasedMove playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerRigidbodyBasedMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Soul")
        {
            playerMovement.jumpOrdashCount -= 1;;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            SoundSystem.instance.PlaySound("Land");
        }
        if (collision.gameObject.tag == "Booster")
        {
            playerMovement.canExceedSpeedOnGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Booster")
        {
            playerMovement.canExceedSpeedOnGround = false;
        }
    }
}

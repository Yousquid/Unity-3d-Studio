using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public PlayerRigidbodyBasedMove PlayerMovement;
    public PlaceObject PlaceObject;
    // Start is called before the first frame update
    void Start()
    {
        PlayerMovement = GetComponent<PlayerRigidbodyBasedMove>();
        PlaceObject = GameObject.FindWithTag("MainCamera").GetComponent<PlaceObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Soul")
        {
            PlayerMovement.jumpOrdashCount -= 1;
            PlaceObject.soulUsed += 1;
        }
        if (other.gameObject.tag == "Soul_Upgrade")
        {
            PlaceObject.soulMax += 1;
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
            PlayerMovement.canExceedSpeedOnGround = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Booster")
        {
            PlayerMovement.canExceedSpeedOnGround = false;
        }
    }
}

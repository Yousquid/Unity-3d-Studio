using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public BoxCollider checkpointTriggerCollider;
    public UIManager UImanager;

    private bool isPlayerInTrigger = false;
    private Vector3 collisionPosition;
    private PlaceObject Placeobject;
    //public PlayerRespawn playerRespawn;

    // Start is called before the first frame update
    void Start()
    {
        checkpointTriggerCollider = GetComponent<BoxCollider>();
        UImanager = GameObject.FindGameObjectWithTag("Manager").GetComponent<UIManager>();
        Placeobject = GameObject.FindWithTag("MainCamera").GetComponent<PlaceObject>();
        //playerRespawn = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerRespawn>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isPlayerInTrigger)
        {
            PlayerRespawn.checkpointPosition = collisionPosition;
            PlaceObject.DestroyAllPlaceObject();
            Placeobject.Respawn();
            UImanager.IsChecking = true;
            //PlayerPrefs.SetInt("soulMax", PlaceObject.soulMax);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            isPlayerInTrigger = true;
            UImanager.IsCheckpoint = true;
            collisionPosition = other.transform.position;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            UImanager.IsCheckpoint = false;
            isPlayerInTrigger = false;
        }
    }
}

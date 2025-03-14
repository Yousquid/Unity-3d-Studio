using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public static Vector3 checkpointPosition;
    public PlayerRigidbodyBasedMove player;
    public PlaceObject PlaceObject;

    private void Start()
    {
        checkpointPosition = transform.position; // Set default checkpoint to starting position
        player = GetComponent<PlayerRigidbodyBasedMove>();
        PlaceObject = GameObject.FindWithTag("MainCamera").GetComponent<PlaceObject>();
    }

    // Update is called once per frame
  

    public void Respawn()
    {
        PlaceObject.DestroyAllPlaceObject();
        PlaceObject.Respawn();
        //PlaceObject.soulMax = PlayerPrefs.GetInt("soulMax");
        player.transform.position = checkpointPosition;
    }
}

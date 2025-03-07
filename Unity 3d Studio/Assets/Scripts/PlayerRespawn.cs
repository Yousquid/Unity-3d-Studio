using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Vector3 checkpointPosition;

    private void Start()
    {
        checkpointPosition = transform.position; // Set default checkpoint to starting position
    }

    // Update is called once per frame
    public void SetCheckpoint(Vector3 newCheckpoint)
    {
        checkpointPosition = newCheckpoint;
    }

    public void Respawn()
    {
        PlaceObject.DestroyAllPlaceObject();
        transform.position = checkpointPosition;
    }
}

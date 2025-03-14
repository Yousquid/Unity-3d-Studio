using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceArea : MonoBehaviour
{
    PlaceObject PlaceObject;
    void Start()
    {
        PlaceObject = GameObject.FindWithTag("MainCamera").GetComponent<PlaceObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlaceObject.maxPlaceDistance = 10;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlaceObject.maxPlaceDistance = 2;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaceObject : MonoBehaviour
{

    [Header("Placement Settings")]
    public GameObject ghost;
    public GameObject placed;
    public List<GameObject> placeableObjects; // List of different objects to place
    public List<GameObject> ghostObjects;
    private int currentObjectIndex = 0; // Tracks selected object type

    public float currentRayDistance = 5f;
    public float currentHeight = 0f;
    public float maxPlaceDistance = 13f;
    public float minPlaceDistance = 0.5f;
    public bool isPlacing = false;

    [Header("Soul Limits")]
    public int soulAmount = 0;
    public int soulMax = 2;

    void Start()
    {
        if (placeableObjects.Count > 0)
        {
            UpdateGhostObject(0);
            ghost = Instantiate(ghostObjects[0]);
            
        }
    }

    void Update()
    {
        // Toggle placement mode
        if (Input.GetMouseButtonDown(1))
        {
            isPlacing = !isPlacing;
        }

        // Change object type with number keys (1, 2, 3...)
        for (int i = 0; i < placeableObjects.Count; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                currentObjectIndex = i;
                UpdateGhostObject(i);
            }
        }

        if (isPlacing)
        {
            HandlePlacementControls();
        }
        else
        {
            ghost.transform.position = Vector3.zero;
        }
    }

    void HandlePlacementControls()
    {
        // Adjust height with scroll wheel
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            currentHeight += scroll * 1.0f;
            currentHeight = Mathf.Clamp(currentHeight, -10.0f, 10.0f);
        }

        // Adjust distance
        if (Input.GetKey(KeyCode.Q) && currentRayDistance < maxPlaceDistance)
        {
            currentRayDistance += 0.1F;
        }
        if (Input.GetKey(KeyCode.E) && currentRayDistance > minPlaceDistance)
        {
            currentRayDistance -= 0.1F;
        }

        // Move ghost object
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        ghost.transform.position = ray.origin + ray.direction * currentRayDistance + new Vector3(0, currentHeight, 0);

        // Place object on left-click
        if (Input.GetMouseButtonDown(0))
        {
            PlaceObjectToScene();
        }
    }

    void PlaceObjectToScene()
    {
        if (soulAmount < soulMax)
        {
            Instantiate(placeableObjects[currentObjectIndex], ghost.transform.position, Quaternion.identity);
        }
        else if (soulAmount >= soulMax)
        {
            GameObject[] souls = GameObject.FindGameObjectsWithTag("Soul");
            foreach (GameObject soul in souls)
            {
                Destroy(soul);
            }
            Instantiate(placeableObjects[currentObjectIndex], ghost.transform.position, Quaternion.identity);
        }
    }

    void UpdateGhostObject( int currentGhostObjectIndex)
    {
        if (ghost != null && placeableObjects.Count > 0)
        {
            Destroy(ghost);
            ghost = Instantiate(ghostObjects[currentGhostObjectIndex]);
        }
    }
}

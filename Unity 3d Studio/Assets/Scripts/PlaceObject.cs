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
    public  int soulMax = 0;
    public  int soulUsed = 0;

    public int graplerAmout = 0;
    public int graplerMax = 0;
    public int graplerUsed = 0;

    public UIManager uiManager;

    public PlayerRigidbodyBasedMove Player;

    void Start()
    {
        //Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerRigidbodyBasedMove>();

        if (placeableObjects.Count > 0)
        {
            UpdateGhostObject(0);
            ghost = Instantiate(ghostObjects[0]);
            
        }

    }

    void Update()
    {
        uiManager.SetSoulNumberAndMaxText(soulMax - soulUsed, soulMax);
        uiManager.SetGrapplerNumberAndMaxtText(graplerMax - graplerUsed, graplerMax);

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
            ghost.transform.position = Vector3.zero + new Vector3(0,-20,0);
        }
    }

    void HandlePlacementControls()
    {

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
        if (currentObjectIndex == 0)
        {
            if (soulAmount < soulMax - soulUsed)
            {
                Instantiate(placeableObjects[currentObjectIndex], ghost.transform.position, Quaternion.identity);
                SoundSystem.instance.PlaySound("Build");
            }
            else if (soulAmount == soulMax - soulUsed && soulMax - soulUsed != 0)
            {
                if (soulMax != 0)
                {

                    DestroyAllPlacedSoulObject();
                    Instantiate(placeableObjects[currentObjectIndex], ghost.transform.position, Quaternion.identity);


                }
            }
        }
        if (currentObjectIndex == 1)
        {
            if (graplerAmout < graplerMax - graplerUsed)
            {
                Instantiate(placeableObjects[currentObjectIndex], ghost.transform.position, Quaternion.identity);
            }
            else if (graplerAmout == graplerMax - graplerUsed && graplerMax - graplerUsed != 0)
            {
                if (graplerMax != 0)
                {
                    print("111");
                    DesstroyAllPlacedGraplerObject();
                    Instantiate(placeableObjects[currentObjectIndex], ghost.transform.position, Quaternion.identity);


                }
            }
        }
        
    }

    public static void DestroyAllPlaceObject()
    {
        DestroyAllPlacedSoulObject();
        DesstroyAllPlacedGraplerObject();
    }
    public static void DestroyAllPlacedSoulObject()
    {
        GameObject[] souls = GameObject.FindGameObjectsWithTag("Soul");
        foreach (GameObject soul in souls)
        {
            Destroy(soul);
        }
    }

    public static void DesstroyAllPlacedGraplerObject()
    {
        GameObject[] graplers = GameObject.FindGameObjectsWithTag("Grappler");
        foreach (GameObject grappler in graplers)
        {
            Destroy(grappler);
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

     public void Respawn()
    {
        soulUsed = 0;
        graplerUsed = 0;
    }
}

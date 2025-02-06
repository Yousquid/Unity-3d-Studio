using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaceObject : MonoBehaviour
{
    public GameObject ghost;
    public GameObject placed;
    public float currentRayDistance = 5f;
    public float currentHeight = 0f;
    public bool isPlacing = false;
    public int soulAmount = 0;
    public int soulMax = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            isPlacing = !isPlacing; // Toggle between true and false
        }

        if (isPlacing)
        {
            float scroll = Input.GetAxis("Mouse ScrollWheel");
            if (scroll != 0)
            {
                currentHeight += scroll * 1.0f; // Adjust height sensitivity
                currentHeight = Mathf.Clamp(currentHeight, -10.0f, 10.0f); // Set min/max height
            }

            if (Input.GetKey(KeyCode.Q))
            {
                currentRayDistance += 0.1F;
            }
            if (Input.GetKey(KeyCode.E))
            {
                currentRayDistance -= 0.1F;
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            ghost.transform.position = ray.origin + ray.direction * currentRayDistance + new Vector3(0, currentHeight, 0);


            if (Input.GetMouseButtonDown(0))
            {
                PlaceObjectToScene();
            }
        }
        else if (!isPlacing)
        { 
            ghost.transform.position = Vector3.zero;
            
        }

        void PlaceObjectToScene()
        {
            if (soulAmount < soulMax)
            {
                Instantiate(placed, ghost.transform.position, Quaternion.identity);
            }
            else if (soulAmount >= soulMax)
            {
                GameObject[] souls = GameObject.FindGameObjectsWithTag("Soul");
                foreach (GameObject soul in souls)
                { 
                    Destroy(soul);
                }
                Instantiate(placed, ghost.transform.position, Quaternion.identity);
            }
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenCenterObjectCheck : MonoBehaviour
{
    public int rayInteractionOffset = 15;
    public RaycastHit[,] hits;
    public bool canTeleport = false;
    public Vector3 teleportDestination;
    public GameObject teleportationTarget;

    // Start is called before the first frame update
    void Start()
    {
       
        hits = new RaycastHit[rayInteractionOffset * 2, rayInteractionOffset * 2];

    }

    // Update is called once per frame
    void Update()
    {
       
        CastRaytoArea();
        canTeleport = CanTeleportWithinArea();

     
       
    }

    public void CastRaytoArea()
    {
        hits = new RaycastHit[rayInteractionOffset*2, rayInteractionOffset*2];
        Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        for (int x = -rayInteractionOffset; x < rayInteractionOffset; x++)
        {
            for (int y = -rayInteractionOffset; y < rayInteractionOffset; y++)
            {
                Ray ray = Camera.main.ScreenPointToRay(screenCenter + new Vector3(x, y, 0));
                RaycastHit hit;
                Physics.Raycast(ray, out hit, Mathf.Infinity);
                if (x < 0 && y < 0)
                {
                    hits[-x, -y] = hit;
                }
                else if (x < 0 && y > 0)
                {
                    hits[-x, y*2] = hit;
                }
                else if (x > 0 && y < 0)
                {
                    hits[x*2, -y] = hit;
                }
                else if (x > 0 && y > 0)
                {
                    hits[x * 2, y*2] = hit;
                }
            }
        }
    }

    public bool CanTeleportWithinArea()
    {
        foreach (RaycastHit hit in hits)
        {
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "Grappler")
                {
                    teleportDestination = hit.collider.transform.position;
                    teleportationTarget = hit.collider.gameObject;
                    return true;
                }
                else if (hit.collider.gameObject.tag == "Soul")
                {
                    return false;
                }
            }
           
        }
        return false;
    }
}

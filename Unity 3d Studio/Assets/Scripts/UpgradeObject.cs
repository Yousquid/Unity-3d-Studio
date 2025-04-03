using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeObject : Soul
{
    // Start is called before the first frame update
    public float floatSpeed = 1.5f; // Speed of floating
    public float floatHeight = 0.5f; // Height of floating
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }
    protected override void Update()
    {
        base.Update();
        float newY = startPos.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);

    }

    protected override void Awake()
    {
        ObjectPlace = GameObject.FindWithTag("MainCamera").GetComponent<PlaceObject>();
    }

    protected override void OnDestroy()
    {
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeObject : Soul
{
    // Start is called before the first frame update
    protected override void Update()
    {
        base.Update();
    }

    protected override void Awake()
    {
        ObjectPlace = GameObject.FindWithTag("MainCamera").GetComponent<PlaceObject>();
    }

    protected override void OnDestroy()
    {
        
    }
}

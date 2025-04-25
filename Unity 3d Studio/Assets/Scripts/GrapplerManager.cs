using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplerManager : MonoBehaviour
{
    private float timer = 0;
    private bool isDestroying = false;
    public PlaceObject ObjectPlace;
    // Start is called before the first frame update
    void Start()
    {

    }

    protected virtual void OnDestroy()
    {
        ObjectPlace.graplerAmout -= 1;
    }

    protected virtual void Awake()
    {
        ObjectPlace = GameObject.FindWithTag("MainCamera").GetComponent<PlaceObject>();
        ObjectPlace.graplerAmout += 1;

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (isDestroying) timer += Time.deltaTime;

        if (timer >= 0.3F)
        {
            Destroy(gameObject);
        }
    }

    
}

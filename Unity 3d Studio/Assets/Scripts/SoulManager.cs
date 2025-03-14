using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{
    private float timer = 0;
    private bool isDestroying = false;
    public PlaceObject ObjectPlace;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void OnDestroy()
    {
        ObjectPlace.soulAmount -= 1;
    }

    private void Awake()
    {
        ObjectPlace = GameObject.FindWithTag("MainCamera").GetComponent<PlaceObject>();
        ObjectPlace.soulAmount += 1;

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (isDestroying) timer+= Time.deltaTime;

        if (timer >= 0.3F)
        {
            Destroy(gameObject);
        }
    }

    protected virtual private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isDestroying = true;
        }
    }
}

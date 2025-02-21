using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    public float boostTimer = 0;
    public float boostTimeDuration = 1f;
    public float boostForce = 5f;
    public bool isCharging = false;
    public Rigidbody rb;
    public Vector3 reflectDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isCharging) boostTimer += Time.deltaTime;

        if (boostTimer > boostTimeDuration)
        {
            rb.AddForce(Vector3.up * boostForce, ForceMode.Impulse);
            boostTimer = 0;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        isCharging = true;


        if (collision.rigidbody != null)
        {
            Rigidbody otherRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            rb = otherRigidbody;
            Vector3 incomingVelocity = otherRigidbody.velocity;
            Vector3 normal = collision.contacts[0].normal;
            reflectDirection = Vector3.Reflect(incomingVelocity, normal);
        }

    }

    private void OnCollisionStay(Collision collision)
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        boostTimer = 0;
        isCharging = !isCharging;
    }

    

}

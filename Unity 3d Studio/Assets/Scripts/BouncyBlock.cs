using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBlock : MonoBehaviour
{
    public float bounceForceMultiplier = 1.1f;
    private PlayerRigidbodyBasedMove player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponentInParent<PlayerRigidbodyBasedMove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody colliderRigidbody = collision.rigidbody;

        if (colliderRigidbody != null && collision.gameObject.tag == "Player")
        {
            Vector3 incomingVelocity = player.lastPlayerVelocity; // Store original velocity
            Vector3 normal = collision.contacts[0].normal; // Get collision normal

            // Reflect velocity based on the collision normal
            Vector3 reflectedVelocity = Vector3.Reflect(incomingVelocity, normal);

            float speed = incomingVelocity.magnitude; // Get original speed

            Vector3 bounceForce = reflectedVelocity.normalized * speed * bounceForceMultiplier;

            colliderRigidbody.AddForce(bounceForce, ForceMode.Impulse);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapler : MonoBehaviour
{
    public ScreenCenterObjectCheck ScreenAimCheck;
    public CharacterController controller; // Character controller for movement
    public float hookForce = 30f; // The force applied when grappling
    public float maxGrappleDistance = 40f; // Maximum grapple distance
    public LayerMask grappleLayer; // Define what surfaces can be grappled
    public float graplerYoofset = 5;

    private Vector3 grapplePoint; // The point to grapple to
    private Vector3 velocity; // Simulated velocity for force-based movement
    private bool isGrappling = false; // Whether the player is currently grappling

    private bool isStoping = false;
    private float stopingTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ScreenAimCheck.canTeleport && Input.GetKeyDown(KeyCode.F))
        {
            FireGrapple();

        }

        if (isGrappling)
        {
            ApplyGrappleForce();
        }

        // Apply gravity if not grounded
        if ( isGrappling)
        {
            velocity.y -= 9.81f * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }

        if (isStoping)
        {
            stopingTimer += Time.deltaTime;
        }
        if (stopingTimer >= 0.35f)
        {
            isGrappling = false;
            velocity = Vector3.zero; // Stop movement
            stopingTimer = 0;
            isStoping = false;
        }
         // Move player using velocity
    }


    void FireGrapple()
    {

        isGrappling = true;
        // Calculate direction and apply an initial burst of force
        Vector3 direction = (ScreenAimCheck.teleportDestination - transform.position + new Vector3(0,graplerYoofset,0)).normalized;
            velocity = direction * hookForce; // Instant pull force
        
    }

    void ApplyGrappleForce()
    {
        Vector3 direction = (ScreenAimCheck.teleportDestination - transform.position+ new Vector3(0,graplerYoofset,0)).normalized;

        // Gradually slow down as we get close to the point
        float distance = Vector3.Distance(transform.position, ScreenAimCheck.teleportDestination + new Vector3(0, graplerYoofset, 0));
        if (distance <= 10f) // Stop grappling when close
        {
            isStoping = true;
            
        }
    }
}

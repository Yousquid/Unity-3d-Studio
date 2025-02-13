using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grapler : MonoBehaviour
{
    [Header("References")]
    public Rigidbody rb;
    public Transform playerTransform;
    public Camera playerCamera;
    public ScreenCenterObjectCheck teleportScript; // Replace with your actual script name

    [Header("Grapple Settings")]
    public KeyCode grappleKey = KeyCode.Mouse1; // Right Mouse Button
    public float grappleSpeed = 20f;
    public float stopDistance = 2f; // Stop when close to target
    public bool isGrappling = false;

    private Vector3 grapplePoint;

    void Update()
    {
        if (Input.GetKeyDown(grappleKey) && teleportScript.canTeleport)
        {
            StartGrapple(teleportScript.teleportDestination);
            Destroy(teleportScript.teleportationTarget);
        }
    }

    void FixedUpdate()
    {
        if (isGrappling)
        {
            GrappleMovement();
        }
    }

    void StartGrapple(Vector3 target)
    {
        isGrappling = true;
        grapplePoint = target;
        rb.useGravity = false; // Optional: Disable gravity while grappling
    }

    void GrappleMovement()
    {
        Vector3 direction = (grapplePoint - playerTransform.position).normalized;
        float distance = Vector3.Distance(playerTransform.position, grapplePoint);

        // Apply force toward the grapple point
        rb.velocity = direction * grappleSpeed;

        // Stop grappling if close enough or colliding
        if (distance < stopDistance)
        {
            StopGrapple();
        }
    }

    void StopGrapple()
    {
        isGrappling = false;
        rb.useGravity = true; // Re-enable gravity
        rb.velocity = Vector3.zero; // Stop movement
    }
}

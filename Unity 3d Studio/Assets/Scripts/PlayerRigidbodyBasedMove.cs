using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRigidbodyBasedMove : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    public Rigidbody rb;
    public bool isGrounded;
    public LayerMask groundLayer; // LayerMask for ground detection


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(moveX, 0, moveZ) * speed;
        rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        isGrounded = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject.layer == 6)
        {
            isGrounded = true;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.layer == 6)
        {
            isGrounded = false;
        }
    }


}

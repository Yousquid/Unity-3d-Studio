using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRigidbodyBasedMove : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;
    public float groundDrag;

    [Header("Jumping")]
    public float jumpForce = 5f;
    public float jumpCooldown;
    public float airMultiplier;
    public int maxJumps = 2; // Allow double jump

    [Header("Dashing")]
    public float dashForce = 20f; // Strength of the dash
    public float dashDuration = 0.2f; // How long the dash lasts
    public float dashCooldown = 1f; // Cooldown time
    public bool canAirDash = true; // Allow dashing in air?
    public int maxDashs = 1;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask groundLayer; // LayerMask for ground detection
    public bool isGround;

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;
    public KeyCode dashKey = KeyCode.LeftShift;

    public Transform orientation;

    public int jumpOrdashCount = 0; // Track jumps
    private bool isReadyToJump = true;

    private bool isDashing = false;
    private bool isDashReady = true;
    private float dashTime = 0f;

    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    Vector3 dashDirection;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        // Ground check
        isGround = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.05f, groundLayer);

        if (isGround)
        {
            jumpOrdashCount = 0; // Reset jumps when grounded
            isReadyToJump = true; // Ensure jump is ready after landing
            jumpOrdashCount = 0;
        }

        MyInput();
        SpeedControl();

        // Handle dash logic
        if (isDashing)
        {
            dashTime -= Time.deltaTime;
            if (dashTime <= 0)
            {
                isDashing = false;
                Invoke(nameof(ResetDash), dashCooldown); // Set cooldown before next dash
            }
        }

        // Handle drag
        rb.drag = isGround ? groundDrag : 0;
    }

    private void FixedUpdate()
    {
        if (!isDashing) // Prevent movement during dash
            MovePlayer();
        else
            rb.velocity = dashDirection * dashForce; // Maintain dash movement
    }

    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // Jump input
        if (Input.GetKeyDown(jumpKey) && isReadyToJump && jumpOrdashCount < maxJumps)
        {
            Jump();
            jumpOrdashCount++;
            isReadyToJump = false;
            Invoke(nameof(ResetJump), jumpCooldown);
        }

        // Dash input
        if (Input.GetKeyDown(dashKey) && isDashReady && (isGround || canAirDash) && jumpOrdashCount < maxDashs)
        {
            StartDash();
            jumpOrdashCount++;
        }
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        Vector3 force = moveDirection.normalized * speed * 10f;

        if (isGround)
            rb.AddForce(force, ForceMode.Force);
        else
            rb.AddForce(force * airMultiplier, ForceMode.Force);
    }

    private void SpeedControl()
    {
        if (isDashing) return; // Ignore speed control during dash

        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > speed)
        {
            Vector3 limitedVel = flatVel.normalized * speed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }

    void Jump()
    {
        SoundSystem.instance.PlaySound("Jump");
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.drag = 0; // Ensure drag doesn��t interfere

        if (isGround)
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        else
            rb.AddForce(transform.up * jumpForce * 0.5f, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        isReadyToJump = true;
    }

    private void StartDash()
    {
        SoundSystem.instance.PlaySound("Dash");
        isDashing = true;
        isDashReady = false;
        dashTime = dashDuration;

        dashDirection = (orientation.forward * verticalInput + orientation.right * horizontalInput).normalized;
        if (dashDirection == Vector3.zero)
            dashDirection = orientation.forward; // Default forward dash if no input

        rb.velocity = Vector3.zero; // Reset velocity before dash
    }

    private void ResetDash()
    {
        isDashReady = true;
    }
}

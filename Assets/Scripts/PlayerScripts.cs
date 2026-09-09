using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 7.0f;
    public float jumpForce = 6.0f;

    [Header("Ground Check")]
    public LayerMask groundMask;
    public float groundCheckDistance = 0.2f;

    Rigidbody rb;
    public float mouseSensitivity = 2.0f;

    private bool isGrounded;
    private bool jumpRequested;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true; // don't let collisions tip the player over
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0f, mouseX, 0f, Space.World);

        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundMask);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpRequested = true;
        }
    }

    void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 forward = transform.forward;
        forward.y = 0f;
        forward.Normalize();

        Vector3 right = transform.right;
        right.y = 0f;
        right.Normalize();

        Vector3 targetVelocity = (forward * v + right * h) * moveSpeed;

        if (jumpRequested)
        {
            targetVelocity.y = jumpForce;
            jumpRequested = false;
        }
        else
        {
            targetVelocity.y = rb.linearVelocity.y; 
        }

        rb.linearVelocity = targetVelocity;
    }
}
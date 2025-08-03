using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimplePlayerMovement1 : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    [Header("Dash / At�lma")]
    public float dashForce = 15f;

    [Header("Mouse Look")]
    public float mouseSensitivity = 2f;
    public Transform cameraPivot; // Kameray� ba�layaca��n bo� GameObject

    private Rigidbody rb;
    private bool isGrounded;
    private float xRotation = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Cursor kilitle
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        HandleMovement();
        HandleMouseLook();
        HandleDash();
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        Vector3 velocity = rb.linearVelocity;

        Vector3 desiredVelocity = move * moveSpeed;
        velocity.x = desiredVelocity.x;
        velocity.z = desiredVelocity.z;

        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void HandleMouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Yatay eksende oyuncuyu d�nd�r
        transform.Rotate(Vector3.up * mouseX);

        // Dikey eksende kameray� d�nd�r
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraPivot.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    void HandleDash()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Vector3 dashDirection = transform.forward;
            rb.AddForce(dashDirection * dashForce, ForceMode.Impulse);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}

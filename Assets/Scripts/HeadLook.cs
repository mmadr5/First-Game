using UnityEngine;

public class HeadLook : MonoBehaviour
{
    public Transform playerBody;  // Assign BB8's body (so head rotates relative to BB8)
    public float sensitivity = 2f; // Adjust how fast the head follows the cursor

    float xRotation = -90f; // Start at -90 degrees

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor

        // Set initial head rotation to -90 degrees (straight ahead)
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    void Update()
    {
        // Get Mouse Input
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Rotate BB8’s Head Left/Right with Mouse X
        playerBody.Rotate(Vector3.up * mouseX);

        // Rotate Head Up/Down (Clamped)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -120f, 0f); // Limit up/down movement
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}

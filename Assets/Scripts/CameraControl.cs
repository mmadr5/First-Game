using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform head; // Assign BB8’s Head in the Inspector
    public float sensitivity = 2f;

    float xRotation = 0f;

void Start()
{
    Cursor.lockState = CursorLockMode.Locked;

    // Force BB8's head to start at a correct rotation
    head.localRotation = Quaternion.Euler(-90f, 180f, 0f);

    // Reset camera rotation to look straight forward
    xRotation = 0f;
    transform.rotation = Quaternion.Euler(0f, head.eulerAngles.y, 0f);
}


    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Rotate BB8's head with the camera
        head.Rotate(Vector3.up * mouseX);

        // Keep camera locked to head's relative rotation
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -45f, 45f); // Prevents extreme tilting
        transform.localRotation = Quaternion.Euler(xRotation, 180f, 0f);
    }
}

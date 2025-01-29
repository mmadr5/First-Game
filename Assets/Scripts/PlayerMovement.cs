using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10.0f;
    public float jumpForce = 500f;
    public Transform cameraTransform; // Assign the camera in Unity Inspector

    public GameObject projectilePrefab; // Drag projectile prefab here in Unity
    public Transform shootingPoint; // Assign shooting position (e.g., BB8's head)
    public float shootingForce = 500f;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; // Locks cursor to screen center
    }

    void Update()
    {
        // Get Input (WASD)
        float moveX = Input.GetAxis("Horizontal"); // A/D → Left/Right
        float moveZ = Input.GetAxis("Vertical");   // W/S → Forward/Backward

        // Calculate Movement Direction (Relative to Camera)
        Vector3 moveDirection = (cameraTransform.forward * moveZ + cameraTransform.right * moveX).normalized;
        moveDirection.y = 0; // Prevents movement in the Y-axis

        // Apply Movement
        rb.linearVelocity = new Vector3(moveDirection.x * speed, rb.linearVelocity.y, moveDirection.z * speed);

        // Jump
        if (Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        // **Shoot Projectile**
        if (Input.GetMouseButtonDown(0)) // Left Mouse Click to Shoot
        {
            ShootProjectile();
        }
    }

    void ShootProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, shootingPoint.position, Quaternion.identity);
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        if (projectileRb != null)
        {
            projectileRb.AddForce(cameraTransform.forward * shootingForce, ForceMode.Impulse);
        }
    }
}

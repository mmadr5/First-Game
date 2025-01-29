using UnityEngine;

public class CarHonk : MonoBehaviour
{
    private AudioSource honkSound;

    private void Start()
    {
        // Get the AudioSource component
        honkSound = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the colliding object has a "Projectile" tag
        if (collision.gameObject.CompareTag("Projectile"))
        {
            // Play the honking sound
            if (honkSound != null)
            {
                honkSound.Play();
            }
        }
    }
}

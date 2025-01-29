using UnityEngine;

public class Fruit : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            ScoreManager.instance.AddPoints(10); // Add 10 points
            Destroy(gameObject); // Destroy the fruit
        }
    }
}

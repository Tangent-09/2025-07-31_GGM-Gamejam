using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float maxDistance = 6f;   // Maximum distance bomb can travel
private Vector2 startPosition;                    // Position where bomb was spawned
private Rigidbody2D rb;                           // Reference to Rigidbody2D component
private bool hasStopped = false;                  // Flag to prevent multiple stops

void Start()
{
    rb = GetComponent<Rigidbody2D>();             // Cache Rigidbody2D
    startPosition = transform.position;           // Record spawn position
}

void Update()
{
    if (hasStopped) return;                       // Do nothing if bomb has already stopped

    float distanceTraveled = Vector2.Distance(startPosition, transform.position);
    if (distanceTraveled >= maxDistance)
    {
        rb.linearVelocity = Vector2.zero;         // Stop movement
        rb.isKinematic = true;                    // Disable physics interactions
        hasStopped = true;                        // Mark as stopped
        Debug.Log("펑");                          // Log explosion (for debug)
    }
}

public void SetMaxDistance(float distance)
{
    maxDistance = distance;                       // Allow external setting of travel limit
}
}

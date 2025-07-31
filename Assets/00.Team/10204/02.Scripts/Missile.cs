using UnityEngine;

public class Missile : MonoBehaviour
{
     private Transform player;                         // Reference to player's transform
    private Rigidbody2D rb;                           // Rigidbody2D component for movement
    private PlayerMovement playerMovement;            // Reference to player's movement script

    [SerializeField] private float followMultiplier = 1f / 3f; // Follower speed ratio relative to player speed

    void Start()
{
    rb = GetComponent<Rigidbody2D>();             // Get this object's Rigidbody2D

    GameObject playerObj = GameObject.FindWithTag("Player");
    if (playerObj != null)
    {
        player = playerObj.transform;             // Cache player's transform
        playerMovement = player.GetComponent<PlayerMovement>(); // Get player's movement script
    }
}

void FixedUpdate()
{
    // Don't move if player or player movement script is not found
    if (player == null || playerMovement == null) return;

    // Calculate normalized direction vector to player
    Vector2 direction = (player.position - transform.position).normalized;

    // Get target speed based on player's speed and the follow multiplier
    float targetSpeed = playerMovement.GetSpeed() * followMultiplier;

    // Move towards the player with calculated speed
    rb.MovePosition(rb.position + direction * targetSpeed * Time.fixedDeltaTime);
}
}

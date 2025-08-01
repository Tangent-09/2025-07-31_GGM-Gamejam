using UnityEngine;

public class Tracker : MonoBehaviour
{
    [SerializeField] private Transform player; // Reference to the player transform (only one player is used)
    [SerializeField] private float followMultiplier = 0.5f; // Multiplier to control how fast this object follows the player

    private Rigidbody2D rb; // Reference to this object's Rigidbody2D component
    private PlayerMovement_1 playerMovement; // Reference to the player's movement script

    void Start()
    {
        // Get the Rigidbody2D component attached to this GameObject
        rb = GetComponent<Rigidbody2D>();

        // If the player Transform is assigned, get the PlayerMovement component from it
        if (player != null)
        {
            playerMovement = player.GetComponent<PlayerMovement_1>();
        }
    }

    void FixedUpdate()
    {
        // If the player or their movement script is missing, stop execution
        if (player == null || playerMovement == null) return;

        // Calculate the normalized direction vector from this object to the player
        Vector2 direction = (player.position - transform.position).normalized;

        // Calculate the speed to follow the player, based on the player's speed and the follow multiplier
        float targetSpeed = playerMovement.GetSpeed() * followMultiplier;

        // Move this object toward the player at the calculated speed
        rb.MovePosition(rb.position + direction * targetSpeed * Time.fixedDeltaTime);
    }
}
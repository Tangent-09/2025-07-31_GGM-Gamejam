using UnityEngine;

public class FlashBang : MonoBehaviour
{
   [Header("Player Tag")]
    [SerializeField] private string playerTag = "Player"; // Tag used to identify the player

    [Header("Explosion Radius")]
    [SerializeField] private float explosionRadius = 3f; // Radius of the explosion effect

    [Header("Fuse Time")]
    [SerializeField] private float fuseTime = 2f; // Delay before the grenade explodes

    private void Start()
    {
        // Call the Explode method after the fuse time
        Invoke(nameof(Explode), fuseTime);
    }

    private void Explode()
    {
        // Find all colliders within the explosion radius
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

    foreach (var hit in hits)
    {
        // Check if the player is within the explosion range
        if (hit.CompareTag(playerTag))
        {
            Debug.Log("Boom - Player hit");
            break; // Stop after detecting one player
        }   
    }

    // Optional: Add visual effects or sound here

    // Destroy the grenade object after explosion
    Destroy(gameObject);
    }

        // Visualize the explosion radius in the editor
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}

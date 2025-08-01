using UnityEngine;

public class mud_road : MonoBehaviour
{
     [SerializeField] private float slowMultiplier = 0.5f; // Movement speed reduced to 50%

    private void OnTriggerEnter2D(Collider2D other)
    {
    // Check if the player entered the trigger zone
        if (other.CompareTag("Player"))
        {
            PlayerMovement_1 player = other.GetComponent<PlayerMovement_1>();
            if (player != null)
            {
                // Apply slow effect
                player.SetSpeedMultiplier(slowMultiplier);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
         // Check if the player exited the trigger zone
        if (other.CompareTag("Player"))
        {
            PlayerMovement_1 player = other.GetComponent<PlayerMovement_1>();
            if (player != null)
            {
                // Restore normal speed
                player.SetSpeedMultiplier(1f);
            }
        }
    }
}

using UnityEngine;

public class ZoneChecker : MonoBehaviour
{
    [Header("Target")]
[SerializeField] private Transform player;           // Reference to the player's transform
[SerializeField] private Collider2D zoneArea;        // Area to check (e.g., a red rectangular trigger zone)

[Header("Increase/Decrease Speed")]
[SerializeField] private float increaseSpeed = 0.1f; // Speed at which the gauge increases inside the zone
[SerializeField] private float decreaseSpeed = 0.1f; // Speed at which the gauge decreases outside the zone

[Header("Gauge Settings")]
[SerializeField] private float maxValue = 50f;       // Maximum value the gauge can reach

private float currentValue = 0f;     // Current gauge value
private bool isCleared = false;     // Whether the gauge has been filled completely

private void Update()
{
    // Convert the player's 3D position to 2D (ignore Z)
    Vector2 playerPos2D = new Vector2(player.position.x, player.position.y);

    // Check if the player's position is inside the zone collider
    if (zoneArea.OverlapPoint(playerPos2D))
    {
        // Increase gauge if player is inside the zone
        currentValue += increaseSpeed;
    }
    else
    {
        // Decrease gauge if player is outside the zone
        currentValue -= decreaseSpeed;
    }

    // Clamp the value so it stays within 0 and maxValue
    currentValue = Mathf.Clamp(currentValue, 0f, maxValue);

    // Check if the gauge has reached its maximum for the first time
    if (!isCleared && currentValue >= maxValue)
    {
        isCleared = true;
        Debug.Log("Cleared!");
    }

    // Debug the current gauge value to the console
    Debug.Log("Current Value: " + currentValue.ToString("F1"));
}

    // Optional: public method to retrieve the current gauge value
    public float GetValue()
    {
        return currentValue;
    }
}

using UnityEngine;

public class TrackerSpown : MonoBehaviour
{
    [SerializeField] private GameObject TrackerPrefab; // Prefab of the chaser object that will be spawned
    [SerializeField] private Vector2 stageSize = new Vector2(20f, 10f); // Size of the stage (width x height)
    [SerializeField] private float spawnOffset = 2f; // Offset to spawn the chaser slightly outside the stage

    private Transform player; // Reference to the player's transform

    void Start()
    {
        // Find the player GameObject using the "Player" tag
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform; // Cache the player's transform
            SpawnChaserFromLeft(); // Spawn a chaser from the left side of the stage
        }
    }

    public void SpawnChaserFromLeft()
    {
        // Check if the prefab or player reference is missing
        if (TrackerPrefab == null || player == null)
        {
            return;
        }

        // Calculate a spawn position just outside the left boundary of the stage
        float leftX = -stageSize.x / 2f - spawnOffset;
        float randomY = Random.Range(-stageSize.y / 2f, stageSize.y / 2f);
        Vector2 spawnPos = new Vector2(leftX, randomY);

        // Instantiate the chaser at the calculated position
        GameObject chaser = Instantiate(TrackerPrefab, spawnPos, Quaternion.identity);

        // Try to get the Tracker script attached to the chaser object
        Tracker chaserScript = chaser.GetComponent<Tracker>();
        if (chaserScript != null)
        {
            // Use reflection to access the private 'player' field in the Tracker script
            var trackerPlayerField = chaserScript.GetType().GetField("player", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (trackerPlayerField != null)
            {
                // Set the private 'player' field in the Tracker script to the actual player transform
                trackerPlayerField.SetValue(chaserScript, player);
            }
        }
    }
}

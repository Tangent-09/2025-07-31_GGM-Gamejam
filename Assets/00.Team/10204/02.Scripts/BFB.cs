using UnityEngine;

public class BFB : MonoBehaviour
{[SerializeField] private GameObject bombPrefab;     // Prefab of the bomb to spawn
[SerializeField] private float BombSpeed = 15f;     // Speed at which the bomb is thrown
[SerializeField] private Vector2 stageSize = new Vector2(20f, 10f); // Size of the stage (width, height)
[SerializeField] private float bombMoveDistance = 6f; // Max distance the bomb should travel

void Start()
{
    SpawnBombFromRandomWall(); // Spawn a bomb once at the start
    // InvokeRepeating(nameof(SpawnBombFromRandomWall), 3f, 10f); // Uncomment to spawn bombs repeatedly every 10s after 3s delay
}

    public void SpawnBombFromRandomWall()
    {
        int side = Random.Range(0, 4); // Randomly select a side: 0 = top, 1 = bottom, 2 = left, 3 = right
        Vector2 spawnPos = Vector2.zero; // Initial spawn position of the bomb
        Vector2 forceDir = Vector2.zero; // Direction to apply force to the bomb

        float halfWidth = stageSize.x / 2f;    // Half width of the stage
        float halfHeight = stageSize.y / 2f;   // Half height of the stage

        // Decide spawn position and force direction based on selected side
        switch (side)
        {
            case 0: // Top
                spawnPos = new Vector2(Random.Range(-halfWidth, halfWidth), halfHeight + 2f); // Slightly above stage
                forceDir = Vector2.down; // Drop downward
                break;
            case 1: // Bottom
                spawnPos = new Vector2(Random.Range(-halfWidth, halfWidth), -halfHeight - 2f); // Slightly below stage
                forceDir = Vector2.up; // Launch upward
                break;
            case 2: // Left
                spawnPos = new Vector2(-halfWidth - 2f, Random.Range(-halfHeight, halfHeight)); // Slightly left of stage
                forceDir = Vector2.right; // Launch to the right
                break;
            case 3: // Right
                spawnPos = new Vector2(halfWidth + 2f, Random.Range(-halfHeight, halfHeight)); // Slightly right of stage
                forceDir = Vector2.left; // Launch to the left
                break;
        }

        // Instantiate the bomb at the calculated position
        GameObject bomb = Instantiate(bombPrefab, spawnPos, Quaternion.identity);

        // Apply force to the bomb's Rigidbody2D
        Rigidbody2D rb = bomb.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Slight random offset to avoid predictable straight lines
            Vector2 randomOffset = new Vector2(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f));
            Vector2 finalDir = (forceDir + randomOffset).normalized;
            rb.AddForce(finalDir * BombSpeed, ForceMode2D.Impulse); // Apply impulse force
        }

        // Set the maximum travel distance for the bomb (handled by Bomb script)
        Bomb bombScript = bomb.GetComponent<Bomb>();
        if (bombScript != null)
        {
            bombScript.SetMaxDistance(bombMoveDistance);
        }
    }
}

using UnityEngine;

public class WallSpawner : MonoBehaviour
{
   [Header("Wall and Hole Prefabs")]
[SerializeField] private GameObject wallPrefab; // Prefab for the wall
[SerializeField] private GameObject holePrefab; // Prefab for the hole

[Header("Spawn Settings")]
[SerializeField] private float spawnInterval = 1.5f; // Time interval between each spawn
[SerializeField] private Transform spawnPoint; // Position where walls and holes will be spawned

[Header("Random Range for Hole Position (Y axis)")]
[SerializeField] private float minHoleY = -2.5f; // Minimum Y position for the hole
[SerializeField] private float maxHoleY = 2.5f;  // Maximum Y position for the hole

private float timer = 0f; // Timer to track time between spawns

void Update()
{
    // Accumulate time since last frame
    timer += Time.deltaTime;

    // Check if it's time to spawn a new wall and hole
    if (timer >= spawnInterval)
    {
        SpawnWallWithHole();
        timer = 0f; // Reset the timer after spawning
    }
}

void SpawnWallWithHole()
{
    // Instantiate the wall at the spawn point
    GameObject wall = Instantiate(wallPrefab, spawnPoint.position, Quaternion.identity);

    // Determine a random Y position for the hole
    float holeY = Random.Range(minHoleY, maxHoleY);
    Vector3 holePosition = wall.transform.position + new Vector3(0f, holeY, 0f);

    // Instantiate the hole at the calculated position
    GameObject hole = Instantiate(holePrefab, holePosition, Quaternion.identity);

    // Make the hole a child of the wall (so they move together, for example)
    hole.transform.SetParent(wall.transform);
}
}

using UnityEngine;

public class MissileSpowner : MonoBehaviour
{
    [SerializeField] public GameObject missilePrefab;     // Prefab of the missile to spawn
    [SerializeField] public Transform spawnPoint;         // The point from where the missile is spawned
    [SerializeField] public float spawnInterval = 1f;     // Time interval between spawns

    [SerializeField] private float timer = 0f;            // Internal timer to track time between spawns

    void Update()
    {
        timer += Time.deltaTime;                          // Increment timer by frame time

        if (timer >= spawnInterval)                       // If enough time has passed
        {
        SpawnMissile();                               // Spawn a missile
        timer = 0f;                                   // Reset the timer
        }
    }

    void SpawnMissile()
    {
        // Instantiate a missile at the spawn point with its current rotation
        Instantiate(missilePrefab, spawnPoint.position, spawnPoint.rotation);
    }
}

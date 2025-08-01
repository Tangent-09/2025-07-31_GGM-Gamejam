using UnityEngine;

public class WallSpawner : MonoBehaviour
{
    [Header("Wall Prefab")]
    [SerializeField] private GameObject wallPrefab; // 구멍이 포함된 벽 프리팹

    [Header("Spawn Settings")]
    [SerializeField] private float spawnInterval = 1.5f; // 생성 간격
    [SerializeField] private Transform spawnPoint;       // 생성 위치

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnWall();
            timer = 0f;
        }
    }

    void SpawnWall()
    {
        Instantiate(wallPrefab, spawnPoint.position, Quaternion.identity);
    }
}

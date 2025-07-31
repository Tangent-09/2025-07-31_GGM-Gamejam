using UnityEngine;

public class WallSpawner : MonoBehaviour
{
   [Header("벽과 구멍 프리팹")]
    [SerializeField] private GameObject wallPrefab;
    [SerializeField] private GameObject holePrefab;

    [Header("스폰 설정")]
    [SerializeField] private float spawnInterval = 1.5f;
    [SerializeField] private Transform spawnPoint;

    [Header("구멍 위치 랜덤 범위 (Y축)")]
    [SerializeField] private float minHoleY = -2.5f;
    [SerializeField] private float maxHoleY = 2.5f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnWallWithHole();
            timer = 0f;
        }
    }

    void SpawnWallWithHole()
    {
        // 벽 생성
        GameObject wall = Instantiate(wallPrefab, spawnPoint.position, Quaternion.identity);

        // 구멍 생성
        float holeY = Random.Range(minHoleY, maxHoleY);
        Vector3 holePosition = wall.transform.position + new Vector3(0f, holeY, 0f);

        GameObject hole = Instantiate(holePrefab, holePosition, Quaternion.identity);
        hole.transform.SetParent(wall.transform); // 벽 자식으로 붙이기
    }
}

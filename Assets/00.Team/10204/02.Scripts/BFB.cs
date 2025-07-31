using UnityEngine;

public class BFB : MonoBehaviour
{
   [SerializeField] private GameObject bombPrefab;     // 폭탄 프리팹
    [SerializeField] private float BombSpeed = 15f;     // 던지는 속도
    [SerializeField] private Vector2 stageSize = new Vector2(20f, 10f); // 스테이지 크기
    [SerializeField] private float bombMoveDistance = 6f; // 폭탄이 이동할 거리

    void Start()
    {
        SpawnBombFromRandomWall();
        // InvokeRepeating(nameof(SpawnBombFromRandomWall), 3f, 10f); // 반복하고 싶다면
    }

    public void SpawnBombFromRandomWall()
    {
        int side = Random.Range(0, 4); // 0: 위, 1: 아래, 2: 왼쪽, 3: 오른쪽
        Vector2 spawnPos = Vector2.zero;
        Vector2 forceDir = Vector2.zero;

        float halfWidth = stageSize.x / 2f;
        float halfHeight = stageSize.y / 2f;

        switch (side)
        {
            case 0:
                spawnPos = new Vector2(Random.Range(-halfWidth, halfWidth), halfHeight + 2f);
                forceDir = Vector2.down;
                break;
            case 1:
                spawnPos = new Vector2(Random.Range(-halfWidth, halfWidth), -halfHeight - 2f);
                forceDir = Vector2.up;
                break;
            case 2:
                spawnPos = new Vector2(-halfWidth - 2f, Random.Range(-halfHeight, halfHeight));
                forceDir = Vector2.right;
                break;
            case 3:
                spawnPos = new Vector2(halfWidth + 2f, Random.Range(-halfHeight, halfHeight));
                forceDir = Vector2.left;
                break;
        }

        GameObject bomb = Instantiate(bombPrefab, spawnPos, Quaternion.identity);

        Rigidbody2D rb = bomb.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            Vector2 randomOffset = new Vector2(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f));
            Vector2 finalDir = (forceDir + randomOffset).normalized;
            rb.AddForce(finalDir * BombSpeed, ForceMode2D.Impulse);
        }

        Bomb bombScript = bomb.GetComponent<Bomb>();
        if (bombScript != null)
        {
            bombScript.SetMaxDistance(bombMoveDistance);
        }
    }
}

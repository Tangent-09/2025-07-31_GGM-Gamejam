using UnityEngine;

public class MissileSpowner : MonoBehaviour
{
     [SerializeField]public GameObject missilePrefab;
    [SerializeField]public Transform spawnPoint;
    [SerializeField]public float spawnInterval = 1f;

    [SerializeField]private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnMissile();
            timer = 0f;
        }
    }

    void SpawnMissile()
    {
        Instantiate(missilePrefab, spawnPoint.position, spawnPoint.rotation);
    }
}

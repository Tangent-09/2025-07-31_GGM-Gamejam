using UnityEngine;

public class TrackerSpown : MonoBehaviour
{
   [SerializeField] private GameObject TrackerPrefab;
    [SerializeField] private Vector2 stageSize = new Vector2(20f, 10f);
    [SerializeField] private float spawnOffset = 2f;

    private Transform player;

    void Start()
    {
        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
            SpawnChaserFromLeft();
        }
    }

    public void SpawnChaserFromLeft()
    {
        if (TrackerPrefab == null || player == null)
        {
            return;
        }
        float leftX = -stageSize.x / 2f - spawnOffset;
        float randomY = Random.Range(-stageSize.y / 2f, stageSize.y / 2f);
        Vector2 spawnPos = new Vector2(leftX, randomY);

        GameObject chaser = Instantiate(TrackerPrefab, spawnPos, Quaternion.identity);
        Tracker chaserScript = chaser.GetComponent<Tracker>();
        if (chaserScript != null)
        {
            var trackerPlayerField = chaserScript.GetType().GetField("player", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (trackerPlayerField != null)
            {
                trackerPlayerField.SetValue(chaserScript, player);
            }
        }
    }
}

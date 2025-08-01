using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    [SerializeField] private GameObject[] spikePatterns; // Array of spike pattern prefabs
[SerializeField] private Transform spawnPoint;        // Position where the pattern will spawn

private void Start()
{
    // Spawn one random spike pattern when the game starts
    SpawnRandomPattern();
}

private void SpawnRandomPattern()
{
    // Choose a random index from the array
    int randomIndex = Random.Range(0, spikePatterns.Length);
    
    // Instantiate the selected spike pattern at the spawn position
    GameObject pattern = Instantiate(spikePatterns[randomIndex], spawnPoint.position, Quaternion.identity);
}
}

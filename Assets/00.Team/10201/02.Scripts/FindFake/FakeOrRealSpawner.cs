using UnityEngine;

public class FakeOrRealSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _realPrefab, _fakePrefab;              // Real and Fake Prefabs
    [SerializeField] private SpawnManager _spawnManager;                       // SpawnManager
    private int _fakeObjectId;                                                 // Id for Fake Object Randomizer

    private void Start()
    {
        _fakeObjectId = Random.Range(0, _spawnManager.SpawnPos.Length);        // Get Randomized Id for Fake Object
        Debug.Log(_fakeObjectId);                                              // [TEMPORARY] fake id log

        for (int i = 0; i < _spawnManager.SpawnPos.Length; i++)                // for every spawn positions, int 'i' increases by 1
        {
            if (i != _fakeObjectId)                                            // if 'i' isn't fake id, spawn Real
            {
                Instantiate(_realPrefab,                                       // Instantiate
                    _spawnManager.SpawnPos[i].transform.position,              // TO: one spawn position
                    Quaternion.identity);                                      // no rotation
            }
            else if (i == _fakeObjectId)                                       // if 'i' IS fake id, spawn Fake
            {
                Instantiate(_fakePrefab,                                       // Instantiate
                    _spawnManager.SpawnPos[i].transform.position,              // TO: one spawn position
                    Quaternion.identity);                                      // no rotation
            }
        }
    }
}

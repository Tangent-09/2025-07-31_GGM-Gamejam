using UnityEngine;

public class FakeOrRealSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _realPrefab, _fakePrefab;
    [SerializeField] private SpawnManager _spawnManager;
    private int _fakeObjectId;

    private void Start()
    {
        _fakeObjectId = Random.Range(0, _spawnManager.SpawnPos.Length);
        Debug.Log(_fakeObjectId);

        for (int i = 0; i < _spawnManager.SpawnPos.Length; i++)
        {
            if (i != _fakeObjectId)
            {
                Instantiate(_realPrefab,
                    _spawnManager.SpawnPos[i].transform.position,
                    Quaternion.identity);
            }
            else if (i == _fakeObjectId)
            {
                Instantiate(_fakePrefab,
                    _spawnManager.SpawnPos[i].transform.position,
                    Quaternion.identity);
            }
        }
    }
}

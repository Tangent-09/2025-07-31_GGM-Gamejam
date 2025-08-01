using UnityEngine;

public class ThornSpawnManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject[] _thornWallPrefabs;                      // ThornWallPatterns Prefabs
    private int _randomPatternId;                                                 // Int Variable to Randomize upcoming Pattern for map
    #endregion
    #region LifeCycle
    private void Start()
    {
        _randomPatternId = Random.Range(0, _thornWallPrefabs.Length);             // Determines which pattern to use for the map
        SpawnThornPattern();                                                      // Then spawns the following pattern
    }
    #endregion
    #region Methods
    private void SpawnThornPattern()                                              // Method used to spawn ThornPattern
    {
        Instantiate(_thornWallPrefabs[_randomPatternId],                          // Instantiates the ThornPattern with inddex num of RandomPatternId
            transform.position,                                                   // on the middle of map (0, 0, 0)
            Quaternion.identity);                                                 // No rotation
    }
    #endregion
}

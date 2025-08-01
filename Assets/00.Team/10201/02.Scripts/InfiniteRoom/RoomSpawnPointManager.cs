using UnityEngine;

public class RoomSpawnPointManager : MonoBehaviour
{
    #region Variable
    [SerializeField] private GameObject _roomSpawnPoint;                // RoomSpawnPoint GameObject Variable
    private Vector2 _nextPos;                                           // Vector2 Variable to store Next position of Spawn Point
    private Vector2 _pos;                                               // Vector2 Variable to store Current position of Spawn Point
    #endregion
    #region LifeCycle
    private void Awake()
    {
        UpdatePos();                                                    // UpatePos Method (Updates Current and Next Position on start)
    }
    #endregion
    #region Public Method
    public void MoveSpawnPoint()                                        // Public Method for Moving SpawnPoint for various spawns
    {
        _roomSpawnPoint.transform.position = _nextPos;                  // Moves SpawnPoint to position of NextPos, Vector2 Variable
        UpdatePos();                                                    // UpdatePos Method
    }
    #endregion
    #region Method
    private void UpdatePos()                                            // Method used to update current and next position
    {
        _pos = _roomSpawnPoint.transform.position;                      // Saves current position to Vector2 Variable
        _nextPos = new Vector2(_pos.x + 100, _pos.y);                   // Determines where next position of SpawnPoint is gonna be
    }
    #endregion
}

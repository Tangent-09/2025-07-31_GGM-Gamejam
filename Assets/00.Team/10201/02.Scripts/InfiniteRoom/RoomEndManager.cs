using UnityEngine;

public class RoomEndManager : MonoBehaviour
{
    #region Variable
    [SerializeField] private GameObject _player;                                    // Player Object Variable, used to detect if player is at the end of room
    [SerializeField] private RoomSpawnManager _roomSpawnManager;                    // RoomSpawnManager Variable
    private GameObject _pointA, _pointB;                                            // GameObject Variable of Point A and B from RoomObject
    private bool _canCheckPos = true;                                               // Bool Variable to control when to check position
    #endregion
    #region LifeCycle
    private void Update()                                                           // For every frame
    {
        if(_canCheckPos)                                                            // If: canCheckPos Bool variable is true
        { 
            CheckPosition();                                                        // Checks Position of Player position
        }
    }
    #endregion
    #region Public Methods
    public void GetRoomPoint(GameObject A, GameObject B)                            // Public Method used to get Point A and B from RoomObject through other Managers
    {
        _pointA = A;                                                                // stores Point A from RoomObject
        _pointB = B;                                                                // stores Point B from RoomObject
        MovePlayer();                                                               // MovePlayer Method
    }
    #endregion
    #region Methods
    private void MovePlayer()                                                       // Method used to move Player to another room
    {
        _player.transform.position = _pointA.transform.position;                    // Player Position = Point A position from other RoomObject that recently spawned
        SetCheckBool(true);                                                         // Sets Bool variable to true
    }

    private void SetCheckBool(bool value) => _canCheckPos = value;                  // Method to set Bool variable (for easier reading)

    private void CheckPosition()                                                    // Method used to check position of Player and attempts to spawn another room
    {
        if (_player.transform.position.x >= _pointB.transform.position.x)           // If: Player position x is bigger than Point B position x
        {
            SetCheckBool(false);                                                    // Sets Bool variable to false because you dont have to check for now
            _roomSpawnManager.SpawnRoom();                                          // Spawns another room through RoomSpawnManager
        }
    }
    #endregion
}

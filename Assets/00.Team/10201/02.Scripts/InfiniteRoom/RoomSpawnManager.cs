using UnityEngine;

public class RoomSpawnManager : MonoBehaviour
{
    #region Variables/Properties
    public GameObject _tempRoomVar { get; private set; }                       // Temporary Property GameObject Variable to store RoomObject prefab temporarily

    [SerializeField] private GameObject _roomPrefab;                           // RoomPrefab, ussed to instantiate and make infinite rooms
    [SerializeField] private GameObject _roomSpawnPoint;                       // RoomSpawnPoint, used to make different each room spawns
    [SerializeField] private InfiniteDetectManager _infDetectManager;          // InfDetectManager Variable
    [SerializeField] private RoomSpawnPointManager _roomSpawnPointManager;     // RoomSpawnPointManager Variable
    #endregion
    #region LifeCycle
    private void Start()
    {
        SpawnRoom();                                                           // On Start, use SpawnRoom method to spawn a room
    }
    #endregion
    #region Public Methods
    public void SpawnRoom()                                                    // Public Mehod used to spawn a Room
    {
        _tempRoomVar = Instantiate(_roomPrefab,                                // Instantiates Room prefab and stores it to Temp variable
          _roomSpawnPoint.transform.position,                                  // Position: RoomSpawnPoint
          Quaternion.identity);                                                // No rotation
        MoveVar();                                                             // MoveVar Method
        MoveRoomSpawn();                                                       // MoveRoomSpawn Method
    }
    #endregion
    #region Methods
    private void MoveVar()                                                     // Method used to transfer Instantiated RoomObject using Temp variable
    {
        _infDetectManager.MoveRoomVar(_tempRoomVar);                           // using MoveRoomVar Method from InfDetectManager
    }

    private void MoveRoomSpawn()                                               // Method used to move Room Spawn Point
    {
        _roomSpawnPointManager.MoveSpawnPoint();                               // using MoveSpawnPoint Method from RoomSpawnPointManager
    }
    #endregion
}

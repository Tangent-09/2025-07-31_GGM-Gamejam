using UnityEngine;

public class InfiniteDetectManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private RoomEndManager _roomEndManager;                           // RoomEndManageer Variable
    private GameObject _roomObject;                                                    // RoomObject Variable
    #endregion
    #region Public Methods
    public void MoveRoomVar(GameObject roomObject)                                     // Public Method used to get RoomObject and store it to self
    {
        StoreRoomVar(roomObject);                                                      // StoreRoomVar Method
    }
    #endregion
    #region Methods
    private void StoreRoomVar(GameObject roomObject)                                   // Method used to move RoomObject to Variable
    {
        if (_roomObject == null)                                                       // If: Variable is null (empty)
        {
            _roomObject = roomObject;                                                  // Just store RoomObject to it
        }
        else if (_roomObject != null)                                                  // If: Variable is not null
        {
            DestroyRoom(_roomObject);                                                  // Destroy the Previous RoomObject
            _roomObject = roomObject;                                                  // And store New RoomObject
        }
        GiveRoomPoints(_roomObject);                                                   // GiveRoomPoints Method
        
    }
    private void GiveRoomPoints(GameObject roomObject)                                 // Method Used to Transfer Point A and B of RoomObject to RoomEndManager
    {
        if (roomObject.TryGetComponent<InfRooms>(out InfRooms rooms))                  // Gets Rooms Component from RoomObject
        {
            _roomEndManager.GetRoomPoint(rooms.PointA, rooms.PointB);                  // Then gets Point A and B from Component and sends them to RoomEndManager
        }
    }

    private void DestroyRoom(GameObject targetObject)                                  // Method Used to destroy RoomObject
    {
        if (targetObject.TryGetComponent<InfRooms>(out InfRooms roomScript))           // Gets Rooms Component from RoomObject
        {
            roomScript.DestroyObject();                                                // then initiates Destroy Method from Rooms Component
        }
    }
    #endregion
}

using UnityEngine;

public class InfRooms : MonoBehaviour
{
    [field: SerializeField] public GameObject PointA { get; private set; }      // Property GameObject variable of Point A, used to move Player
    [field: SerializeField] public GameObject PointB { get; private set; }      // Property GameObject variable of Point B, used to spawn new Room
    public void DestroyObject()                                                 // Public Method to destroy this Object from other managers
    {
        Destroy(gameObject);                                                    // Destroys this GameObject
    }
}

using UnityEngine;

public class Platform : MonoBehaviour
{
    [field: SerializeField] public GameObject PointA { get; private set; }            // Desstination A
    [field: SerializeField] public GameObject PointB { get; private set; }            // Destination B
    [field: SerializeField] public Rigidbody2D RbCompo { get; private set; }          // Rigidbody2D Component

}

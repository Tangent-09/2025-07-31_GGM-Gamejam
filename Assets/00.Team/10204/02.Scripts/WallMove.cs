using UnityEngine;

public class WallMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f; // Speed at which the object moves to the left

void Update()
{
    // Move the object to the left every frame at a constant speed
    transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
}
}

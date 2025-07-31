using UnityEngine;

public class WallMove : MonoBehaviour
{
     [SerializeField] private float moveSpeed = 2f;

    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }
}

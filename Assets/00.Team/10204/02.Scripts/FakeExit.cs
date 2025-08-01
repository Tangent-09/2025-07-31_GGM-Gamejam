using UnityEngine;

public class FakeExit : MonoBehaviour
{
<<<<<<< Updated upstream
    [Header("플레이어 태그")]
    [SerializeField] private string playerTag = "Player";

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            Debug.Log("사망");
        }
    }
}
=======
   [Header("Player Tag")]
[SerializeField] private string playerTag = "Player";  // The tag used to identify the player object

private void OnCollisionEnter2D(Collision2D collision)
{
    // Check if the object we collided with has the player tag
    if (collision.gameObject.CompareTag(playerTag))
    {
        Debug.Log("사망");  // Log "Death" when the player collides
    }
}
}
>>>>>>> Stashed changes

using UnityEngine;

public class FakeExit : MonoBehaviour
{
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

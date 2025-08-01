using UnityEngine;

public class electric_fan : MonoBehaviour
{
   [SerializeField] private float windForce = 10f;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // 오른쪽에서 왼쪽으로 바람을 밀어냄 (x축 음수 방향)
                Vector2 force = Vector2.left * windForce;
                rb.AddForce(force);
            }
        }
    }

}

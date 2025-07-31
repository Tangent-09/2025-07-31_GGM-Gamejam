using UnityEngine;

public class Tracker : MonoBehaviour
{
    [SerializeField] private Transform player; // 하나만 사용
    [SerializeField] private float followMultiplier = 0.5f;

    private Rigidbody2D rb;
    private PlayerMovement playerMovement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (player != null)
        {
            playerMovement = player.GetComponent<PlayerMovement>();
        }
    }

    void FixedUpdate()
    {
        if (player == null || playerMovement == null) return;

        Vector2 direction = (player.position - transform.position).normalized;
        float targetSpeed = playerMovement.GetSpeed() * followMultiplier;

        rb.MovePosition(rb.position + direction * targetSpeed * Time.fixedDeltaTime);
    }
}
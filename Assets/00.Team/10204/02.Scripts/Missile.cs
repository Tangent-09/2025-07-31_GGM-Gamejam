using UnityEngine;

public class Missile : MonoBehaviour
{
     private Transform player;
    private Rigidbody2D rb;
    private PlayerMovement playerMovement;

    [SerializeField] private float followMultiplier = 1f / 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        GameObject playerObj = GameObject.FindWithTag("Player");
        if (playerObj != null)
        {
            player = playerObj.transform;
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

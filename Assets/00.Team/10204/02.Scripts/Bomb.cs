using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private float maxDistance = 6f;
    private Vector2 startPosition;
    private Rigidbody2D rb;
    private bool hasStopped = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startPosition = transform.position;
    }

    void Update()
    {
        if (hasStopped) return;

        float distanceTraveled = Vector2.Distance(startPosition, transform.position);
        if (distanceTraveled >= maxDistance)
        {
            rb.linearVelocity = Vector2.zero;
            rb.isKinematic = true;
            hasStopped = true;
            Debug.Log("펑");
        }
    }

    public void SetMaxDistance(float distance)
    {
        maxDistance = distance;
    }
}

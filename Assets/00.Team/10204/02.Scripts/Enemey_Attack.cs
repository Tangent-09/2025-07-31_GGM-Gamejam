using UnityEngine;

public class Enemey_Attack : MonoBehaviour
{
    [Header("Firing Settings")]
[SerializeField] private GameObject bulletPrefab; // Prefab of the bullet to shoot
[SerializeField] private Transform firePoint;     // Where the bullet will be spawned
[SerializeField] private float fireRate = 1f;     // Bullets per second

private float nextFireTime = 0f;                  // Time until next bullet can be fired
private Transform player;                         // Reference to the player's transform

void Start()
{
    // Find player GameObject by tag and store its transform
    GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
    if (playerObj != null)
    {
        player = playerObj.transform;
    }
}

void Update()
{
    if (player == null) return;                   // Exit if player not found

    // Fire only if enough time has passed since the last shot
    if (Time.time >= nextFireTime)
    {
        FireAtPlayer();                            // Shoot a bullet toward the player
        nextFireTime = Time.time + 1f / fireRate;  // Schedule next fire time
    }
}

void FireAtPlayer()
{
    // Calculate direction from firePoint to player
    Vector2 direction = (player.position - firePoint.position).normalized;

    // Instantiate bullet at firePoint position
    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);

    // Add velocity to the bullet
    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
    if (rb != null)
    {
        rb.linearVelocity = direction * 10f;       // Bullet speed is fixed at 10
    }
}
}

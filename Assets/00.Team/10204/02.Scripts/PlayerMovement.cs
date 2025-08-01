using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(MyPlayerInput))]
public class PlayerMovement : MonoBehaviour
{
     [SerializeField] private float speed = 5f; // Base movement speed
[SerializeField, Range(0f, 1f)] private float iceFriction = 0.98f; // Sliding friction on ice (closer to 1 = more slippery)

private float speedMultiplier = 1f;
private Rigidbody2D rb;
private MyPlayerInput playerInput;

private bool onIce = false;
private Vector2 iceVelocity = Vector2.zero;

void Start()
{
    rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
    playerInput = GetComponent<MyPlayerInput>(); // Get custom input handler
}

void FixedUpdate()
{
    Vector2 moveInput = playerInput.MovementInput; // Read movement input

    if (onIce)
    {
        if (moveInput != Vector2.zero)
        {
            // Apply acceleration on ice
            iceVelocity += moveInput.normalized * speed * speedMultiplier * Time.fixedDeltaTime;
            // Clamp maximum sliding speed
            iceVelocity = Vector2.ClampMagnitude(iceVelocity, speed * speedMultiplier);
        }

        // Apply friction to simulate sliding
        iceVelocity *= iceFriction;
        rb.MovePosition(rb.position + iceVelocity * Time.fixedDeltaTime); // Move with ice velocity
    }
    else
    {
        // Normal movement on regular ground
        Vector2 move = moveInput * speed * speedMultiplier * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + move);
    }
}

public float GetSpeed()
{
    return speed * speedMultiplier; // Get current movement speed
}

public void SetSpeedMultiplier(float multiplier)
{
    speedMultiplier = multiplier; // Apply speed changes from external effects
}

public void SetOnIce(bool isOnIce)
{
    if (isOnIce && !onIce)
    {
        // When entering ice, apply initial sliding force
        iceVelocity = playerInput.MovementInput.normalized * speed * speedMultiplier;
    }

    onIce = isOnIce;

    if (!isOnIce)
    {
        // Reset velocity when leaving ice
        iceVelocity = Vector2.zero;
    }
}
}

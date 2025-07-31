using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(MyPlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f; // Movement speed of the player, editable in the Inspector

private Rigidbody2D rb; // Reference to the Rigidbody2D component
private MyPlayerInput playerInput; // Reference to the custom input handler script

void Start()
{
    // Get the Rigidbody2D component attached to this GameObject
    rb = GetComponent<Rigidbody2D>();

    // Get the MyPlayerInput component for reading movement input
    playerInput = GetComponent<MyPlayerInput>();
}

void FixedUpdate()
{
    // Get the current movement input from the player
    Vector2 move = playerInput.MovementInput;

    // Move the player by applying the input vector scaled by speed and delta time
    rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
}

// Public method to return the current movement speed
public float GetSpeed()
{
    return speed;
}
}

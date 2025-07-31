using UnityEngine;

public class MyPlayerInput : MonoBehaviour
{
    // Property to store movement input vector, accessible publicly but only set privately
    public Vector2 MovementInput { get; private set; }

    [SerializeField] private bool isReversed = false; // Flag to determine whether movement input should be reversed

    void Update()
    {
        // Get horizontal and vertical input from player (e.g., keyboard or controller)
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        // Create a 2D vector from input values
        Vector2 input = new Vector2(x, y);

        // If reverse is enabled, invert the input vector
        if (isReversed)
            input *= -1f;

        // Save the input vector to the MovementInput property
        MovementInput = input;
    }

    // Public method to set the reverse movement flag
    public void SetReverse(bool value)
    {
        isReversed = value;
    }
}

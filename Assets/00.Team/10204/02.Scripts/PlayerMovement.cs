using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(MyPlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Rigidbody2D rb;
    private MyPlayerInput playerInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<MyPlayerInput>();
    }

    void FixedUpdate()
    {
        Vector2 move = playerInput.MovementInput;
        rb.MovePosition(rb.position + move * speed * Time.fixedDeltaTime);
    }
}

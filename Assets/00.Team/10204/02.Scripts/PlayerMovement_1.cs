using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(MyPlayerInput))]
public class PlayerMovement_1 : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField, Range(0f, 1f)] private float iceFriction = 0.98f; // 미끄러짐 강도 (1에 가까울수록 오래 미끄러짐)

    private float speedMultiplier = 1f;
    private Rigidbody2D rb;
    private MyPlayerInput playerInput;

    private bool onIce = false;
    private Vector2 iceVelocity = Vector2.zero;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<MyPlayerInput>();
    }

    void FixedUpdate()
    {
        Vector2 moveInput = playerInput.MovementInput;

        if (onIce)
        {
            if (moveInput != Vector2.zero)
            {
                iceVelocity += moveInput.normalized * speed * speedMultiplier * Time.fixedDeltaTime;
                iceVelocity = Vector2.ClampMagnitude(iceVelocity, speed * speedMultiplier);
            }

            iceVelocity *= iceFriction;
            rb.MovePosition(rb.position + iceVelocity * Time.fixedDeltaTime);
        }
        else
        {
            Vector2 move = moveInput * speed * speedMultiplier * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + move);
        }
    }

    public float GetSpeed()
    {
        return speed * speedMultiplier;
    }

    public void SetSpeedMultiplier(float multiplier)
    {
        speedMultiplier = multiplier;
    }

    public void SetOnIce(bool isOnIce)
    {
        if (isOnIce && !onIce)
        {
            // 처음 얼음에 들어갈 때 현재 속도 저장
            iceVelocity = playerInput.MovementInput.normalized * speed * speedMultiplier;
        }

        onIce = isOnIce;

        if (!isOnIce)
        {
            iceVelocity = Vector2.zero;
        }
    }
}

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 moveDir => Player.Instance.PlayerInput.MoveDir;
    private Rigidbody2D rigid => Player.Instance.Rigidbody;
    [SerializeField] private float walkSpeed = 5f;

    private void FixedUpdate()
    {
        rigid.linearVelocity = moveDir * walkSpeed;
    }
}

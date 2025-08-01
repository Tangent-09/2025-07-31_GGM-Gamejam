using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Vector2 moveDir => Player.Instance.PlayerInput.MoveDir;
    private Animator animator => Player.Instance.Animator;
    private readonly int moveFront = Animator.StringToHash("Front");
    private readonly int moveBack = Animator.StringToHash("Back");
    private readonly int moveSide = Animator.StringToHash("Side");
    private readonly int isMove = Animator.StringToHash("isMove");

    private void Update()
    {
        SetAnimation();
        FlipX();

    }
    private void FlipX()
    {
        if (moveDir.x < 0)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else if (moveDir.x > 0)
            transform.rotation = Quaternion.Euler(0, 180, 0);
    }
    private void SetAnimation()
    {
        #region Moving Check
        if (moveDir != Vector2.zero)
            animator.SetBool(isMove, true);
        else
            animator.SetBool(isMove, false);
        #endregion
        #region Front&Back Check
        if (moveDir.y > 0)
        {
            animator.SetBool(moveBack, true);
            animator.SetBool(moveFront, false);
            animator.SetBool(moveSide, false);
        }
        else if (moveDir.y < 0)
        {
            animator.SetBool(moveFront, true);
            animator.SetBool(moveBack, false);
            animator.SetBool(moveSide, false);
        }
        else if (moveDir.y == 0 && moveDir.x != 0)
        {
            animator.SetBool(moveSide, true);
            animator.SetBool(moveBack, false);
            animator.SetBool(moveFront, false);
        }
        else
        {
            animator.SetBool(moveFront, false);
            animator.SetBool(moveBack, false);
            animator.SetBool(moveSide, false);
        }
        #endregion
    }
}

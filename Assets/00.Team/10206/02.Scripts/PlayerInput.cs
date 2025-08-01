using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public Vector2 MoveDir { get; private set; }

    public void OnMove(InputValue inputValue)
    {
        MoveDir = inputValue.Get<Vector2>().normalized;
        print(MoveDir);
    }
}

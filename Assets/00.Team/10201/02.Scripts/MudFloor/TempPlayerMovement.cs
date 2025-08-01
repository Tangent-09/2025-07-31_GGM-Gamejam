using Unity.Hierarchy;
using UnityEngine;
using UnityEngine.InputSystem;

public class TempPlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rbCompo;                    // Do i need to explain these ---------------------------------------------------------
    private Vector2 _moveDir;
    private float _movementSpeed = 5f;

    private void OnMove(InputValue value)
    {
        _moveDir = value.Get<Vector2>();
    }

    private void Update()
    {
        _rbCompo.linearVelocity = _moveDir.normalized * _movementSpeed;
    }                                                                // -------------------------------------------------------------------------------------

    public void MultiplyMovement(float value)                          // Method that helps mud to adjust player speed
    {
        _movementSpeed *= value;                                     // Multiplies value to player speed
    }

    public void DivideMovement(float value)                            // Method that helps mud to adjust player speed, mostly used to reset player speed back
    {
        _movementSpeed /= value;                                     // Divides value to player speed
    }
}

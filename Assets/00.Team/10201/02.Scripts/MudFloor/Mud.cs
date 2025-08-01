using UnityEngine;

public class Mud : MonoBehaviour
{
    #region Variable
    [SerializeField] private TempPlayerMovement _playerMovement;        // PlayerMovement Variable
    private float _slowAmount = 0.5f;                                   // Float Variable for how slow player is gonna be on mud
    #endregion
    #region Physics
    private void OnTriggerEnter2D(Collider2D collision)                 // When Player Enters Mud:
    {
        MultSpeed(_slowAmount);                                         // Player Speed is Slowed
    }

    private void OnTriggerExit2D(Collider2D collision)                  // When Player Exits Mud:
    {
        DivideSpeed(_slowAmount);                                       // Player Speed is back to neutral
    }
    #endregion
    #region Methods
    private void MultSpeed(float value)                                 // Method used to slow or make player fast; In here, this makes player slow
    {
        _playerMovement.MultiplyMovement(value);                        // By Multiplying number lower than 1 to player speed, player speed is decreased
    }

    private void DivideSpeed(float value)                               // Method used to reset player speed back.
    {
        _playerMovement.DivideMovement(value);                          // By Dividing same amount which you have multiplied, player speed is back to neutral.
    }
    #endregion
}

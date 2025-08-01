using UnityEngine;

public class DetectCircle : MonoBehaviour
{
    [SerializeField] private DetectManager _detectManager;              // DetectManager variable
    private void OnTriggerEnter2D(Collider2D collision)                 // On touched by player ---------
    {
        _detectManager.StartDetect();                                   // Initiate StartDetect Method from DetectManager
        Destroy(gameObject);                                            // then destroy this object
    }
}

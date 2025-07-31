using UnityEngine;

public class Doors : MonoBehaviour
{
    [SerializeField] private bool _isReal = false;              // [TEMP/MIGHT CHANGE] is door real?

    private void OnTriggerEnter2D(Collider2D collision)         // On Trigger:
    {
        if (_isReal)                                            // if: door is real
            Debug.Log("Mission Complete!");                     // Mission Complete
    }
}

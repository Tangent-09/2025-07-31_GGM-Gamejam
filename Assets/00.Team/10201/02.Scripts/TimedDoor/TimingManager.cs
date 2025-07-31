using UnityEngine;

public class TimingManager : MonoBehaviour
{
    public float _timedSlice { get; private set; }        // Float Variable to store timing of door when to enable/disable

    private void Awake()
    {
        _timedSlice = 0.405f;                             // Can be changed later
    }
}

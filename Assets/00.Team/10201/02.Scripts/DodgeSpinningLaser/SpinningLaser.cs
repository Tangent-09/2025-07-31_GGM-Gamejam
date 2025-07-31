using UnityEngine;

public class SpinningLaser : MonoBehaviour
{
    private int _rotateSpeed = 3;                                            // Int Variable to store Rotating Speed                       
    private void FixedUpdate()
    {
        transform.RotateAround(gameObject.transform.position,                // Point
            Vector3.back,                                                    // Axis
            _rotateSpeed);                                                   // Angle(Rotate Speed)
    }
}

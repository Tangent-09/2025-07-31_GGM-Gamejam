using System;
using System.Collections;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    #region Variables
    [SerializeField] private Platform _platform;                                                    // Platform Object
    private Action PlatformEvent;                                                                   // Action(Event) Variable to subscribe all the methods and invoke them all at once
    private Vector2 _moveDir;                                                                       // Direction of Platform Movement
    private bool _dirChange = false;                                                                // Bool variable to detect if platform has changed direction to opposite
    private bool _platformStop = false;                                                             // Bool variable to detect if platform has paused or not
    private float _speed = 1f;                                                                      // Float variable of how fast the platform is going to move
    private float _stopDuration = 5f;                                                               // Float variable for how long the platform is going to stay paused
    #endregion
    #region LifeCycle
    private void Start()
    {
        SetMoveDir();                                                                               // Set the Move Direction after start and before moving
        PlatformEvent += MovePlatform;                                                              // Subscribe Method to Event (Moving Platform Method)
        PlatformEvent += SetMoveDir;                                                                // This too                  (Setting Move Direction Method)
        PlatformEvent += StopCheck;                                                                 // Obvioussly this too       (Method to check if platform has to stop)
    }

    private void Update()
    {
        if (!_platformStop)                                                                         // if: Platform is not stopped
        {
            PlatformEvent?.Invoke();                                                                // Invoke(run) the subscribed methods
        }
    }

    private void OnDestroy()                                                                        // On Destroy, Unsubscribe all methods and stop all the Coroutines to prevent annything bad
    {
        PlatformEvent -= MovePlatform;                                                              // Unsubscribe
        PlatformEvent -= SetMoveDir;                                                                // Unsubscribe v2
        PlatformEvent -= StopCheck;                                                                 // Unsubscribe v3
        StopAllCoroutines();                                                                        // Stop Coroutines
    }
    #endregion
    #region Methods
    private void MovePlatform()                                                                     // Method used to Move Platform
    {
        _platform.RbCompo.linearVelocity = _moveDir.normalized * _speed;                            // Rigidbody LinearVelocity = Move Direction(Normalized) * Speed
    }
    private void SetMoveDir()                                                                       // Method used to Set Moving Direction
    {
        if (!_dirChange)                                                                            // If DirectionChange is snot true
            _moveDir = _platform.PointB.transform.position - gameObject.transform.position;         // MoveDirection(Destination): PointB
        else                                                                                        // else (if DirectionChange is true)
            _moveDir = _platform.PointA.transform.position - gameObject.transform.position;         // MoveDirection(Destination): PointA
    }

    private void StopCheck()                                                                        // Method used to check if Platform has to stop (is at destination)
    {
        if (Mathf.Abs(_moveDir.x) >= 0.1f)                                                          // if Absolute value of MoveDirection's x value is higher than 0.1
            return;                                                                                 // then nothing happens
        else                                                                                        // else
        {
            _platformStop = true;                                                                   // Platform Stop = true
            StartCoroutine(ChangeDirection());                                                      // Start ChangeDirection Coroutine
        }
    }
    #endregion
    #region Coroutines
    private IEnumerator ChangeDirection()                                                           // Coroutine for platform to stay paused and change direction
    {
        _moveDir = Vector2.zero;                                                                    // Reset the Moving Direction(Destination)
        MovePlatform();                                                                             // Use this Method or platform not stop moving to the previous destination
        yield return new WaitForSeconds(_stopDuration);                                             // Wait for StopDuration
        if (!_dirChange)                                                                            // If Direction Change is false
            _dirChange = true;                                                                      // Change the Direction
        else                                                                                        // If Direction Change was true
            _dirChange = false;                                                                     // Reset the Direction to default
        _platformStop = false;                                                                      // Platform can move now
    }
    #endregion
}

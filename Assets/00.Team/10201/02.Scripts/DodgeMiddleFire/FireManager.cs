using System.Collections;
using UnityEngine;

public class FireManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private GameObject _fireObject;             // FireObject
    [SerializeField] private GameObject _warningObject;          // WarningObject
    [SerializeField] private FireTimeManager _fireTimeManager;   // FireTimeManager

    private Rigidbody2D _fireRbCompo;                            // Rigidbody2D from FireObject

    private bool _isWarning = false;                             // Bool Variable to detect when to enable Warning
    private bool _isFire = false;                                // Bool Variable to detect when to initiate Fire
    private int _warningDuration;                                // Int Variable to store how long the warning is going to stay enabled for
    private int _fireSpeed = 50;                                 // Int Variable to store how fast Fire is
    private int _fireDuration = 2;                               // Int Variable tp stpre how long the Fire is going to stay enableed for
    #endregion
    #region LifeCycle
    private void Start()
    {
        _fireRbCompo = _fireObject.GetComponent<Rigidbody2D>();               // Rigidbody2D 
        _warningDuration = _fireTimeManager.fireDelayTime;                    // Get WarningDuration from FireTimeManager's FireDelayTime
        ReadyFire();                                                          // Start Preparing to initiate Fire
    }

    private void Update()
    {
        if(_isWarning)                                                        // If: Warning is activated (from FireTimeManager)
        {
            _isWarning = false;                                               // disable bool variable
            StartCoroutine(ShowWarning());                                    // and enable warning from coroutine
        }
        if(_isFire)                                                           // If: Fire is activated (from FireTimeManager)
        {
            _isFire = false;                                                  // disable bool variable
            StartCoroutine(FireChariot());                                    // and enable the CHARIOT
        }
    }
    private void OnDestroy()                                                  // On Destroy, Stop all Coroutines to prevent anything bad
    {
        StopAllCoroutines();
    }
    #endregion
    #region Methods
    private void ReadyFire()
    {
        _fireTimeManager.StartCountdown();                                    // initiate Countdown in FireTimeManager
    }
    private void ResetFire()                                                  // Method Used to Reset Fire to re-use it later
    {
        _fireRbCompo.linearVelocity = Vector2.zero;                           // Reset the Moving direction and speed
        _fireObject.SetActive(false);                                         // Disable the Fire
        _fireRbCompo.transform.position = transform.position;                 // Move Fire back to its original Place
        ReadyFire();                                                          // Now we're ready to fire!!!!!!!!
    }
    #endregion
    #region Coroutines
    private IEnumerator ShowWarning()                                         // Coroutine Used to enable Warning
    {
        _warningObject.SetActive(true);                                       // Enable Warning Object
        yield return new WaitForSeconds(_warningDuration);                    // Wait for WarningDuration
        _warningObject.SetActive(false);                                      // Disable Warning Object
    }
    private IEnumerator FireChariot()                                         // Coroutine used to activate fire
    {
        _fireObject.SetActive(true);                                          // Enable Fire
        _fireRbCompo.linearVelocity = Vector2.left * _fireSpeed;              // Move Fire
        yield return new WaitForSeconds(_fireDuration);                       // Wait for FireDuration
        ResetFire();                                                          // Reset it
    }
    #endregion
    #region Public Method
    public void SetWarning(bool value) => _isWarning = value;                 // Methhod to set warning bool variable from other manager
    public void SetFire(bool value) => _isFire = value;                       // Method to set fire bool variable from other manager
    #endregion
}

using System.Collections;
using UnityEngine;

public class FireTimeManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private FireManager _fireManager;              // FireManager
    public int fireInvTime { get; private set; } = 3;               // Fire Invisible Time(Duration)
    public int fireDelayTime { get; private set; } = 2;             // Fire Delay Time(Warning Duration)
    #endregion
    #region LifeCycle
    private void OnDestroy()                                        // On Destroy, stop all Coroutines to prevent anything bad
    {
        StopAllCoroutines();
    }
    #endregion
    #region Method
    public void StartCountdown()                             // Method to help other manager to initiate Countdown
    {
        StartCoroutine(Countdown());
    }
    #endregion
    #region Coroutine
    private IEnumerator Countdown()                          // Countdown Coroutine
    {
        yield return new WaitForSeconds(fireInvTime);        // Waits for Fire Invisible Time
        _fireManager.SetWarning(true);                       // Then Activates Warning from FireManager
        yield return new WaitForSeconds(fireDelayTime);      // Waits for Fire Delay Time
        _fireManager.SetFire(true);                          // Then Activates Fire from FirManager
    }
    #endregion
}

using System.Collections;
using UnityEngine;

public class DetectManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private Hole _hole;                              // Hole Object
    private float _delayTime = 2f;                                    // Delay Time until Hole is visible
    #endregion
    #region LifeCycle
    private void OnDestroy()                                          // On Destroy, Stop all coroutines to prevent anything bad
    {
        StopAllCoroutines();
    }
    #endregion
    #region Public Methods
    public void StartDetect()                                         // Public method to access coroutine from other objects
    {
        StartCoroutine(DetectDelay());                                // Starts Delay Coroutine
    }
    #endregion
    #region Coroutines
    private IEnumerator DetectDelay()                                 // Coroutine to wait for Delay and initiate detect method in Hole object
    {
        yield return new WaitForSeconds(_delayTime);                  // Waits for DelayTime
        _hole.Detected();                                             // Then initiate detected method from Hole object
    }
    #endregion
}

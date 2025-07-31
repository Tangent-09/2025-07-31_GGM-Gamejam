using System;
using System.Collections;
using UnityEngine;

public class TimedDoorManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private TimingManager _timingManager;                          // TimingManager
    [SerializeField] private GameObject[] _doorObjects;                             // DoorObjects
    #endregion
    #region LifeCycle
    private void Start()
    {
        StartCoroutine(TimedOpenAndClose(_timingManager._timedSlice));              // On start, activate the door
    }
    private void OnDestroy()                                                        // On Destroy, stop all coroutine to prevent something bad
    {
        StopAllCoroutines();                                                        
    }
    #endregion
    #region Coroutines
    private IEnumerator TimedOpenAndClose(float slicedTime)                         // Used Coroutine
    {
        yield return new WaitForSeconds(slicedTime);                                // slicedTime from TimingManager
        for(int i = 0; i < _doorObjects.Length; i++)
        {
            if (_doorObjects[i].activeSelf)                                         // if abled then
                _doorObjects[i].SetActive(false);                                   // disable
            else                                                                    // else, if disabled then
                _doorObjects[i].SetActive(true);                                    // able 
        }
        StartCoroutine(TimedOpenAndClose(_timingManager._timedSlice));              // Repeat
    }
    #endregion
}

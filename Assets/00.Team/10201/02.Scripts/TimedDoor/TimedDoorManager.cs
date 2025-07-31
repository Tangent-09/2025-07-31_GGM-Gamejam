using System;
using System.Collections;
using UnityEngine;

public class TimedDoorManager : MonoBehaviour
{
    [SerializeField] private TimingManager _timingManager;                          // TimingManager
    [SerializeField] private GameObject[] _doorObjects;                             // DoorObjects
    private void Start()
    {
        StartCoroutine(TimedOpenAndClose(_timingManager._timedSlice));              // On start, activate the door
    }

    private IEnumerator TimedOpenAndClose(float slicedTime)                         // Used Coroutine
    {
        yield return new WaitForSeconds(slicedTime);                                // slicedTime from TimingManager
        for(int i = 0; i < _doorObjects.Length; i++)
        {
            if (_doorObjects[i].activeSelf)                                         // if O then O -> X, if X then X -> O
                _doorObjects[i].SetActive(false);
            else
                _doorObjects[i].SetActive(true);
        }
        StartCoroutine(TimedOpenAndClose(_timingManager._timedSlice));              // Repeat
    }

    private void OnDestroy()                                                        // On Destroy, stop all coroutine to prevent something bad
    {
        StopAllCoroutines();
    }
}

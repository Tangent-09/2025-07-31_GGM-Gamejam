
using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class ClickKeyManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private TextManager _textManager;     // TextManager                                                          
    [SerializeField] private TimeManager _timeManager;     // TimeManager
    [SerializeField] private PanelManager _panelManager;   // PanelManager
    private int _randomKeyId;                              // Int Variable for Randomizing required key
    private int _missionId;                                // Int Variable for Randomizing required condition

    private int _clickCount;                               // Int Variable to store how many times the key has been pressed
    private int _clickQuota;                               // Int Variable to store how many times you need to press

    private bool _missionStart = false;                    // Bool Variable to detect if mission(time) has started or not
    private bool _missionEnd = false;                      // Bool Variable to detect if mission(time) has ended or not
    #endregion
    #region LifeCycle
    private void Start()
    {
        _randomKeyId = UnityEngine.Random.Range(0, 22);                          // Randomized Key from Q ~ M (WASD excluded)
        _clickQuota = UnityEngine.Random.Range(5, 31);                           // Randomized Required count from 5 ~ 30
        _missionId = UnityEngine.Random.Range(0, 2);                             // Randomized Required Condition (0 - Press more than N, 1 - Press N or less times)
        Debug.Log($"random key: {_randomKeyId}");                                // [TEMP] log of randommized key
        StartCoroutine(DelayBeforeStart());                                      // Delay before mission start
    }

    private void Update()
    {
        if (_missionStart)                                                       // if: Mission(timer) started   -------------------
        {                                                                        // Switch !!WARNING VERY LONG!!, detects randomized number of _randomKeyId and helps player to press the right key to increase count
            #region KeyInput
            switch (_randomKeyId)                                                // Depending on randomKeyId..
            {
                case 0:                                                          // If KeyId = 0, press Q key to increase count
                    {
                        if (Keyboard.current.qKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 1:                                                          // If KeyId = 1, press E key to increase count
                    {
                        if (Keyboard.current.eKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 2:                                                          // If KeyId = 2, press R key to increase count
                    {
                        if (Keyboard.current.rKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 3:                                                          // If KeyId = 3, press T key to increase count
                    {
                        if (Keyboard.current.tKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 4:                                                          // If KeyId = 4, press Y key to increase count
                    {
                        if (Keyboard.current.yKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 5:                                                          // If KeyId = 5, press U key to increase count
                    {
                        if (Keyboard.current.uKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 6:                                                          // If KeyId = 6, press I key to increase count
                    {
                        if (Keyboard.current.iKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 7:                                                          // If KeyId = 7, press O key to increase count
                    {
                        if (Keyboard.current.oKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 8:                                                          // If KeyId = 8, press P key to increase count
                    {
                        if (Keyboard.current.pKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 9:                                                          // If KeyId = 9, press F key to increase count
                    {
                        if (Keyboard.current.fKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 10:                                                         // If KeyId = 10, press G key to increase count
                    {
                        if (Keyboard.current.gKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 11:                                                         // If KeyId = 11, press H key to increase count
                    {
                        if (Keyboard.current.hKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 12:                                                         // If KeyId = 12, press J key to increase count
                    {
                        if (Keyboard.current.jKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 13:                                                         // If KeyId = 13, press K key to increase count
                    {
                        if (Keyboard.current.kKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 14:                                                         // If KeyId = 14, press L key to increase count
                    {
                        if (Keyboard.current.lKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 15:                                                         // If KeyId = 15, press Z key to increase count
                    {
                        if (Keyboard.current.zKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 16:                                                         // If KeyId = 16, press X key to increase count
                    {
                        if (Keyboard.current.xKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 17:                                                         // If KeyId = 17, press C key to increase count
                    {
                        if (Keyboard.current.cKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 18:                                                         // If KeyId = 18, press V key to increase count
                    {
                        if (Keyboard.current.vKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 19:                                                         // If KeyId = 19, press B key to increase count
                    {
                        if (Keyboard.current.bKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 20:                                                         // If KeyId = 20, press N key to increase count
                    {
                        if (Keyboard.current.nKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 21:                                                         // If KeyId = 21, press M key to increase count
                    {
                        if (Keyboard.current.mKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
            }
            #endregion
            if (_clickCount >= _clickQuota && _missionId == 0)                   // if: count > quota, and mission id is 1, pause the timer immediately and complete mission
            {
                Debug.Log("Mission Complete!!");                                 // [TEMP] debug log Mission Complete
                _missionStart = false;                                           // disable bool missionStart variable to prevent anything bad
                StopTime();                                                      // Pause Countdown from TimeManager immediately to prevent anything bad
            }
        }
        if (_missionEnd)                                                         // if: Mission(timer) ended     -------------------
        {
            switch (_missionId)                                                  // Depending on Mission Id...
            {
                case 0:                                                          // 0 - Press more than N 
                    {
                        if (_clickCount < _clickQuota)                           // if: count < quota, Mission Fail :<
                        {
                            Debug.Log("Mission Fail!! D:");                      // [TEMP] debug log Mission Fail
                        }
                        _missionEnd = false;                                     // disable bool missionEnd variable
                        break;
                    }
                case 1:                                                          // 1 - Press N or less times
                    {
                        if (_clickCount <= _clickQuota)                          // if: count <= quota, Mission Complete!
                            Debug.Log("Mission Complete!!");                     // [TEMP] debug log Mission Complete
                        else
                            Debug.Log("Mision Fail! D:");                        // else(fail), Mission Fail :<
                        _missionEnd = false;                                     // disable bool missionEnd variable
                        break;
                    }
            }
        }
        _textManager.SetClickedText($"{_clickCount}");                           // Update text for Click(press) count
    }

    private void OnDestroy()                                                     // On Destroy, stop all Coroutines to prevent anything bad
    {
        StopAllCoroutines();
    }
    #endregion
    #region Coroutine
    private IEnumerator DelayBeforeStart()                                       // Delay Coroutine to give Player some time before mission start
    {
        yield return new WaitForSeconds(3f);                                     // Wait for 3 Seconds before mission start
        switch (_missionId)                                                      // Depending on the MissionId... -------------------------------------------
        {
            case 0:
                {                                                                // 0 - Press more than N
                    _textManager.SetClickText($"PRESS {(KeyEnum)Enum.GetValues(typeof(KeyEnum)).GetValue(_randomKeyId)} KEY " +                 // Set ClickText "Press {KeyEnum} key for {quota} times"
                        $"FOR {_clickQuota} TIMES!!!");
                    break;
                }
            case 1:
                {                                                                // 1 - Press N or less times
                    _textManager.SetClickText($"PRESS {(KeyEnum)Enum.GetValues(typeof(KeyEnum)).GetValue(_randomKeyId)} KEY " +                 // Set ClickText "Press {KeyEnum} key for {quota} or less times"
                      $"FOR {_clickQuota} OR LESS TIMES!!!");
                    break;
                }
        }
        _timeManager.CountDown();                                                // Start Countdown from TimeManager
    }
    #endregion
    #region Public Method
    public void SetBoolMissionStart(bool value) => _missionStart = value;        // MissionStart Method

    public void SetBoolMissionEnd(bool value) => _missionEnd = value;            // MissionEnd Method

    public void StopTime()                                                       // StopTime, used when player filled quota before time run out
    {
        _timeManager.StopAllCoroutines();                                        // Stop Coroutines from TimeManager to prevent anything bad
        _panelManager.SetMissionPanelActive(false);                              // Disable Panel
    }
    #endregion
}

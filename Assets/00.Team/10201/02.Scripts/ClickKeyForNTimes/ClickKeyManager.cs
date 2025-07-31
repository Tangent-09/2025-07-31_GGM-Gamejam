
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
        if (_missionStart)                                                       // if: Mission(timer) started
        {                                                                        // Switch !!WARNING VERY LONG!!, detects randomized number of _randomKeyId and helps player to press the right key to increase count
            #region KeyInput
            switch (_randomKeyId)
            {
                case 0:
                    {
                        if (Keyboard.current.qKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 1:
                    {
                        if (Keyboard.current.eKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 2:
                    {
                        if (Keyboard.current.rKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 3:
                    {
                        if (Keyboard.current.tKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 4:
                    {
                        if (Keyboard.current.yKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 5:
                    {
                        if (Keyboard.current.uKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 6:
                    {
                        if (Keyboard.current.iKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 7:
                    {
                        if (Keyboard.current.oKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 8:
                    {
                        if (Keyboard.current.pKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 9:
                    {
                        if (Keyboard.current.fKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 10:
                    {
                        if (Keyboard.current.gKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 11:
                    {
                        if (Keyboard.current.hKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 12:
                    {
                        if (Keyboard.current.jKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 13:
                    {
                        if (Keyboard.current.kKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 14:
                    {
                        if (Keyboard.current.lKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 15:
                    {
                        if (Keyboard.current.zKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 16:
                    {
                        if (Keyboard.current.xKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 17:
                    {
                        if (Keyboard.current.cKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 18:
                    {
                        if (Keyboard.current.vKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 19:
                    {
                        if (Keyboard.current.bKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 20:
                    {
                        if (Keyboard.current.nKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
                case 21:
                    {
                        if (Keyboard.current.mKey.wasPressedThisFrame)
                            _clickCount++;
                        break;
                    }
            }
            #endregion 
            if (_clickCount >= _clickQuota && _missionId == 0)                   // if: count > quota, and mission id is 1, pause the timer immediately and complete mission
            {
                Debug.Log("Mission Complete!!");
                _missionStart = false;
                StopTime();
            }
        }
        if (_missionEnd)                                                         // if: Mission(timer) ended
        {
            switch (_missionId)
            {
                case 0:                                                          // 0 - Press more than N
                    {
                        if (_clickCount < _clickQuota)                           // if: count < quota, Mission Fail :<
                        {
                            Debug.Log("Mission Fail!! D:");
                        }
                        _missionEnd = false;
                        break;
                    }
                case 1:                                                          // 1 - Press N or less times
                    {
                        if (_clickCount <= _clickQuota)                          // if: count <= quota, Mission Complete!
                            Debug.Log("Mission Complete!!");
                        else
                            Debug.Log("Mision Fail! D:");                        // else(fail), Mission Fail :<
                        _missionEnd = false;
                        break;
                    }
            }
        }
        _textManager.SetClickedText($"{_clickCount}");                           // Update text for Click(press) count
    }

    private IEnumerator DelayBeforeStart()                                       // Delay Coroutine to give Player some time before mission start
    {
        yield return new WaitForSeconds(3f);
        switch (_missionId)
        {
            case 0:
                {                                                                // 0 - Press more than N
                    _textManager.SetClickText($"PRESS {(KeyEnum)Enum.GetValues(typeof(KeyEnum)).GetValue(_randomKeyId)} KEY " +
                        $"FOR {_clickQuota} TIMES!!!");
                    break;
                }
            case 1:
                {                                                                // 1 - Press N or less times
                    _textManager.SetClickText($"PRESS {(KeyEnum)Enum.GetValues(typeof(KeyEnum)).GetValue(_randomKeyId)} KEY " +
                      $"FOR {_clickQuota} OR LESS TIMES!!!");
                    break;
                }
        }
        _timeManager.CountDown();                                                // Start Countdown from TimeManager
    }

    public void SetBoolMissionStart(bool value) => _missionStart = value;        // MissionStart Method

    public void SetBoolMissionEnd(bool value) => _missionEnd = value;            // MissionEnd Method

    public void StopTime()                                                       // StopTime, used when player filled quota before time run out
    {
        _timeManager.StopAllCoroutines();
        _panelManager.SetMissionPanelActive(false);
    }
}

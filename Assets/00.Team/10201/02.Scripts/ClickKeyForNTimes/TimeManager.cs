using System.Collections;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private TextManager _textManager;                                              // TextManager
    [SerializeField] private ClickKeyManager _clickKeyManager;                                      // ClickKeyManager
    [SerializeField] private PanelManager _panelManager;                                            // PanelManager
    private int _timeLimit;                                                                         // Int Variable to store How many time has left
    #endregion Variables
    private void Start()
    {
        _timeLimit = Random.Range(3, 11);                                                         // Randomized Time Limit between 3 ~ 10
        Debug.Log(_timeLimit);                                                                    // [TEMP] log Timelimit
    }

    public void CountDown()                                                                       // Mission Time Countdown
    {
        StartCoroutine(CountdownStart());
    }

    private IEnumerator CountdownStart()                                                          // Countdown Coroutine
    {
        SetMissionStart(true);
        SetMissionPanel(true);
        while (_timeLimit > 0)                                                                    // while Time is bigger than zero
        {
            _textManager.SetTimeText($"Time: {_timeLimit}");                                      // Update Text of TimeText
            yield return new WaitForSeconds(1f);                                                  // Wait for !s
            _timeLimit--;                                                                         // Then Decrease TimeLimit Variable by 1
        }
        SetMissionPanel(false);
        SetMissionStart(false);
        SetMissionEnd(true);
    }

    private void SetMissionPanel(bool value) => _panelManager.SetMissionPanelActive(value);       // MissionPanel Method from PanelManager
    private void SetMissionStart(bool value) => _clickKeyManager.SetBoolMissionStart(value);      // MissionStart Method from ClickKeyManager
    private void SetMissionEnd(bool value) => _clickKeyManager.SetBoolMissionEnd(value);          // MissionEnd Method from ClickKeyManager
}

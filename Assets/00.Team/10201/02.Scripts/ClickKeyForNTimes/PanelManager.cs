using UnityEngine;

public class PanelManager : MonoBehaviour
{
    [SerializeField] private GameObject _missionPanel;                                   // Mission Panel UI

    private void Awake()
    {
        _missionPanel.SetActive(false);
    }

    public void SetMissionPanelActive(bool value) => _missionPanel.SetActive(value);     // Mission Panel Method
}

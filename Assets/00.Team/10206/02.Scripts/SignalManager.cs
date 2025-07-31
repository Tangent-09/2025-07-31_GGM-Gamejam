using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SignalManager : MonoBehaviour
{
    public TMP_Text signalText;
    public Image background;
    [SerializeField] private int waitingTime;

    public void Start()
    {
        SetRandomWaiting();
    }

    private void SetRandomWaiting()
    {
        waitingTime = Random.Range(1, 5);

        StartCoroutine(SignalWaiting());
    }

    private IEnumerator SignalWaiting()
    {
        yield return new WaitForSeconds(waitingTime);

        signalText.text = "GO!";
        background.color = new Color(0, 1, 0, 0.2f);
    }
}

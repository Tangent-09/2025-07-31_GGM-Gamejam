using TMPro;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    #region Variables(Properties)
    [field: SerializeField] public TextMeshProUGUI ClickText { get; private set; }  // Text to tell which and how many to press
    [field: SerializeField] public TextMeshProUGUI ClickedText { get; private set; }// Text to tell how many times you've pressed
    [field: SerializeField] public TextMeshProUGUI TimeText { get; private set; }   // Text to tell how many times has left
    #endregion
    #region Public Methods
    public void SetClickText(string text)                                           // Set ClickText's Text
    {
        ClickText.text = text;
    }
    public void SetClickedText(string text)                                         // Set ClickedText's Text
    {
        ClickedText.text = text;
    }
    public void SetTimeText(string text)                                            // Set TimeText's Text
    {
        TimeText.text = text;
    }
    #endregion
}

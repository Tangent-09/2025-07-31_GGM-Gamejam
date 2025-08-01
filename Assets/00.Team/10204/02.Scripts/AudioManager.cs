using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour 
{
    [Header("Audio Source")]
[SerializeField] private AudioSource audioSource; // Reference to the AudioSource component

[Header("Slider UI")]
[SerializeField] private Slider volumeSlider; // Reference to the UI slider controlling volume

void Start()
{
    if (audioSource == null || volumeSlider == null)
    {
        Debug.LogWarning("AudioSource or VolumeSlider is not assigned.");
        return;
    }

    // Set the slider's initial value to match the current audio volume
    volumeSlider.value = audioSource.volume;

    // Add listener to apply volume changes when the slider is adjusted
    volumeSlider.onValueChanged.AddListener(SetVolume);
}

public void SetVolume(float volume)
{
    if (audioSource != null)
        audioSource.volume = volume; // Set the AudioSource volume to the slider's value
}
}
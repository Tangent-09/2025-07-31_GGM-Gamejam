using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;                        // AudioMixer Variable
    [SerializeField] Slider slider;                                        // SlideVariable

    public void SetAudioVolume(float value)                                // Method used in Slider to get Float value
    {
        audioMixer.SetFloat("MasterParam", Mathf.Log10(value) * 20);       // Sets Volume of AudioMixer to value
    }
}

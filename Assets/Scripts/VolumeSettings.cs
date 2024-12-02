using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer mainMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider soundsSlider;

    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        mainMixer.SetFloat("Music", Mathf.Log10(volume)*20);
    }

    public void SetSoundsVolume()
    {
        float volume = soundsSlider.value;
        mainMixer.SetFloat("Sounds", Mathf.Log10(volume) * 20);
    }


}


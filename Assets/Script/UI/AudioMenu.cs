using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioMenu : MonoBehaviour
{
    [SerializeField]private Toggle musicToggle;
    [SerializeField] private Slider musicSlider;

    [SerializeField] private Toggle audioToggle;
    [SerializeField] private Slider audioSlider;
    private void Awake()
    {
        musicToggle = transform.Find("Music").GetComponentInChildren<Toggle>();
        musicSlider = transform.Find("Music").GetComponentInChildren<Slider>();

        audioToggle = transform.Find("Audio").GetComponentInChildren<Toggle>();
        audioSlider = transform.Find("Audio").GetComponentInChildren<Slider>();
    }
    private void Start()
    {
        musicToggle.isOn = AudioManager.Instance.isMusicOn;
        musicSlider.value = AudioManager.Instance.musicVolume;
        audioToggle.isOn = AudioManager.Instance.isAudioOn;
        audioSlider.value = AudioManager.Instance.audioVolume;
    }
   
    public void MusicToggleValueChanged()
    {
        AudioManager.Instance.SetMusicOn(musicToggle.isOn);
    }

    public void MusicSliderValueChanged()
    {
        //AudioManager.Instance.musicVolume = musicSlider.value;
        AudioManager.Instance.SetMusicVolume(musicSlider.value);
    }

    public void AudioToggleValueChanged()
    {
        //AudioManager.Instance.isAudioOn = audioToggle.isOn;
        AudioManager.Instance.SetAudioOn(audioToggle.isOn);
    }

    public void AudioSliderValueChanged()
    {
        //AudioManager.Instance.audioVolume = audioSlider.value;
        AudioManager.Instance.SetAudioVolume(audioSlider.value);
    }
}

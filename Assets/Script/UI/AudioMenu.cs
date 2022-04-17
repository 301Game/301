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
        musicToggle.isOn = GameManager.Instance.isMusicOn;
        musicSlider.value = GameManager.Instance.musicVolume;
        audioToggle.isOn = GameManager.Instance.isAudioOn;
        audioSlider.value = GameManager.Instance.audioVolume;
    }
   
    public void MusicToggleValueChanged()
    {
        GameManager.Instance.isMusicOn = musicToggle.isOn;
    }

    public void MusicSliderValueChanged()
    {
        GameManager.Instance.musicVolume = musicSlider.value;
    }

    public void AudioToggleValueChanged()
    {
        GameManager.Instance.isAudioOn = audioToggle.isOn;
    }

    public void AudioSliderValueChanged()
    {
        GameManager.Instance.audioVolume = audioSlider.value;
    }
}

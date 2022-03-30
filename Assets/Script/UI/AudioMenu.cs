using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioMenu : MonoBehaviour
{
    private Toggle toggle;
    private Slider slider;
    private void Awake()
    {
        toggle = GetComponentInChildren<Toggle>();
        slider = GetComponentInChildren<Slider>();
    }
    private void Start()
    {
        AudioManager.Instance.SetMusicOn(toggle.isOn);
        AudioManager.Instance.SetMusicVolume(slider.value);
    }
    public void ToggleValueChanged()
    {
        AudioManager.Instance.SetMusicOn(toggle.isOn);
    }

    public void SliderValueChanged()
    {
        AudioManager.Instance.SetMusicVolume(slider.value);
    }
}

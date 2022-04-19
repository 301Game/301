using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    private AudioSource audioSource;

    private bool isMusicOn;
    private float musicVolume;
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);

        audioSource = GetComponent<AudioSource>();
    }
    
    public void SetMusicOn(bool value)
    {
        isMusicOn = value;
        MusicSettingChanged();
    }
    public void SetMusicVolume(float value)
    {
        musicVolume = value;
        MusicSettingChanged();
    }
    public void PlayOnce(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
    private void MusicSettingChanged()
    {
        if (isMusicOn)
        {
            audioSource.volume = musicVolume;
        }
        else
        {
            audioSource.volume = 0f;
        }
        
        
    }
}

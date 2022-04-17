using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class AudioManager : Singleton<AudioManager>
{
    //private AudioSource audioSource;
    private MusicManager musicManager;
    public bool isMusicOn;
    public float musicVolume;

    public bool isAudioOn;
    public float audioVolume;
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
        musicManager = FungusManager.Instance.MusicManager;
        getAudioSettingData();
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

    public void SetAudioOn(bool value)
    {
        isAudioOn = value;

    }
    public void SetAudioVolume(float value)
    {
        audioVolume = value;
        
    }
    public void PlayOnce(AudioClip clip)
    {
        if (isAudioOn)
        {
            Debug.Log(audioVolume);
            //audioSource.PlayOneShot(clip, audioVolume);
        }
        
    }
    private void MusicSettingChanged()
    {
        if (isMusicOn)
        {
            musicManager.SetAudioVolume(musicVolume, 0, null);
        }
        else
        {
            musicManager.SetAudioVolume(0f, 0, null);
        }
    }
    private void getAudioSettingData()
    {
        //FIXME:从本地存储中读取设定
        isMusicOn = true;
        musicVolume = 1f;
        isAudioOn = true;
        audioVolume = 1f;
}
    //}
    //public void PlayMusic(AudioClip clip, float time)
    //{
    //    if(clip != null)
    //    {
    //        StartCoroutine(SwitchMusic(clip,time));
    //    }
    //    else
    //    {
    //        StartCoroutine(FadeInMusic(clip, time));
    //    }
    //}

    //IEnumerator SwitchMusic(AudioClip clip, float time)
    //{
    //    yield return StartCoroutine(FadeOutMusic(time / 2));
    //    yield return StartCoroutine(FadeInMusic(clip, time / 2));
    //}
    //IEnumerator FadeOutMusic(float time)
    //{
    //    while(audioSource.volume > 0)
    //    {
    //        audioSource.volume = Mathf.Lerp(audioSource.volume, 0, time);
    //        yield return null;
    //    }

    //}
    //IEnumerator FadeInMusic(AudioClip clip, float time)
    //{
    //    audioSource.clip = clip;
    //    audioSource.volume = 0;
    //    audioSource.Play();
    //    while (audioSource.volume < musicVolume)
    //    {
    //        audioSource.volume = Mathf.Lerp(0, musicVolume, time);
    //        yield return null;
    //    }
    //}
}

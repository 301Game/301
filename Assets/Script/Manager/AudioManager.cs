using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class AudioManager : Singleton<AudioManager>
{
    private AudioSource audioSource;

    private bool isMusicOn { get { return GameManager.Instance.isMusicOn; } set { GameManager.Instance.isMusicOn = value; } }
    private float musicVolume { get { return GameManager.Instance.musicVolume; } set { GameManager.Instance.musicVolume = value; } }

    private bool isAudioOn { get { return GameManager.Instance.isAudioOn; } set { GameManager.Instance.isAudioOn = value; } }
    private float audioVolume { get { return GameManager.Instance.audioVolume; } set { GameManager.Instance.audioVolume = value; } }
protected override void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        Debug.Log("onEnable");
    }
    private void OnDisable()
    {
        Debug.Log("OnDisable");
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
            audioSource.PlayOneShot(clip, audioVolume);
        }
        
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
    public void PlayMusic(AudioClip clip, float time)
    {
        if(clip != null)
        {
            StartCoroutine(SwitchMusic(clip,time));
        }
        else
        {
            StartCoroutine(FadeInMusic(clip, time));
        }
    }

    IEnumerator SwitchMusic(AudioClip clip, float time)
    {
        yield return StartCoroutine(FadeOutMusic(time / 2));
        yield return StartCoroutine(FadeInMusic(clip, time / 2));
    }
    IEnumerator FadeOutMusic(float time)
    {
        while(audioSource.volume > 0)
        {
            audioSource.volume = Mathf.Lerp(audioSource.volume, 0, time);
            yield return null;
        }

    }
    IEnumerator FadeInMusic(AudioClip clip, float time)
    {
        audioSource.clip = clip;
        audioSource.volume = 0;
        audioSource.Play();
        while (audioSource.volume < musicVolume)
        {
            audioSource.volume = Mathf.Lerp(0, musicVolume, time);
            yield return null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Fungus;

public class AudioManager : Singleton<AudioManager>
{
    //private AudioSource audioSource;
<<<<<<< HEAD
   // private MusicManager musicManager;
    public bool isMusicOn;
    public float musicVolume;
=======
    private MusicManager musicManager;
    public AudioData_SO audioData;

    #region public data from audioData
    public bool isMusicOn { get { return audioData.isMusicOn; } set { audioData.isMusicOn = value; } }
    public float musicVolume { get { return audioData.musicVolume; } set { audioData.musicVolume = value; } }

    public bool isAudioOn { get{ return audioData.isAudioOn; } set { audioData.isAudioOn = value; } }

    public float audioVolume { get { return audioData.audioVolume; } set { audioData.audioVolume = value; } }
    #endregion
>>>>>>> e5cfa3a7acdd009d62a46b0ed0429a33a7c66636

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
<<<<<<< HEAD
     //   musicManager = FungusManager.Instance.MusicManager;
        getAudioSettingData();
=======
        musicManager = FungusManager.Instance.MusicManager;
        MusicSettingChanged();
>>>>>>> e5cfa3a7acdd009d62a46b0ed0429a33a7c66636
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
        if(audioData == null)
        {
            Debug.LogError("Please set the Data File In Inspector");
            return;
        }
        if (isMusicOn)
        {
           // musicManager.SetAudioVolume(musicVolume, 0, null);
        }
        else
        {
           // musicManager.SetAudioVolume(0f, 0, null);
        }
    }
}

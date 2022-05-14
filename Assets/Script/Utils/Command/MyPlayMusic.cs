using UnityEngine;
using Fungus;

[CommandInfo("Other",
             "My Play Music",
             "使用AudioManager中设置的音量播放音乐")]
[AddComponentMenu("")]
public class MyPlayMusic : Command
{
    [Tooltip("Music sound clip to play")]
    [SerializeField] protected AudioClip musicClip;

    [Tooltip("Time to begin playing in seconds. If the audio file is compressed, the time index may be inaccurate.")]
    [SerializeField] protected float atTime;

    [Tooltip("The music will start playing again at end.")]
    [SerializeField] protected bool loop = true;

    [Tooltip("Length of time to fade out previous playing music.")]
    [SerializeField] protected float fadeDuration = 1f;

    #region Public members

    public override void OnEnter()
    {
        var musicManager = FungusManager.Instance.MusicManager;

        float startTime = Mathf.Max(0, atTime);
        musicManager.SetAudioVolume(AudioManager.Instance.musicVolume, 0, null);
        musicManager.PlayMusic(musicClip, loop, fadeDuration, startTime);

        Continue();
    }

    public override string GetSummary()
    {
        if (musicClip == null)
        {
            return "Error: No music clip selected";
        }

        return musicClip.name;
    }

    public override Color GetButtonColor()
    {
        return new Color32(242, 209, 176, 255);
    }

    #endregion
}
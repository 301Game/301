using UnityEngine;
using Fungus;

[CommandInfo("Other",
             "MyPlaySound",
             "使用AudioManager中设置的音量播放音效")]
[AddComponentMenu("")]
public class MyPlaySound : Command
{
    [Tooltip("Sound effect clip to play")]
    [SerializeField] protected AudioClip soundClip;

    [Tooltip("Wait until the sound has finished playing before continuing execution.")]
    [SerializeField] protected bool waitUntilFinished;

    [Tooltip("play loop")]
    [SerializeField] protected bool isLoop;
    protected virtual void DoWait()
    {
        Continue();
    }

    #region Public members

    public override void OnEnter()
    {
        if (soundClip == null)
        {
            Continue();
            return;
        }

        var musicManager = FungusManager.Instance.MusicManager;
        var volume = AudioManager.Instance.audioVolume;
        if (AudioManager.Instance.isAudioOn)
        {
            musicManager.PlayAmbianceSound(soundClip, isLoop, volume);
            
        }

        if (waitUntilFinished)
        {
            Invoke("DoWait", soundClip.length);
        }
        else
        {
            Continue();
        }
    }

    public override string GetSummary()
    {
        if (soundClip == null)
        {
            return "Error: No sound clip selected";
        }

        return soundClip.name;
    }

    public override Color GetButtonColor()
    {
        return new Color32(242, 209, 176, 255);
    }

    #endregion
}

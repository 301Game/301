using UnityEngine;
using Fungus;
using UnityEngine.Playables;

[CommandInfo("Other",
             "PlayTimeLine",
             "²¥·ÅTimeLine")]
[AddComponentMenu("")]
public class PlayTimeLine : Command
{
    [Tooltip("Sound effect clip to play")]
    [SerializeField] protected PlayableDirector playableDirector;

    protected virtual void DoWait()
    {
        Continue();
    }

    #region Public members

    public override void OnEnter()
    {
        if (playableDirector == null)
        {
            Continue();
            return;
        }
        playableDirector.Play();
        Invoke("Continue", (float)playableDirector.duration);
        
    }

    public override string GetSummary()
    {
        if (playableDirector == null) return "";
        return "Play:" + playableDirector.name;
    }

    public override Color GetButtonColor()
    {
        return new Color32(242, 209, 176, 255);
    }

    #endregion
}

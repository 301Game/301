using UnityEngine;
using Fungus;

[CommandInfo("Other",
             "AboveSay",
             "The dialog show above the character")]
[AddComponentMenu("")]
public class AboveSay : Command
{
    [Tooltip("要说的内容")]
    [TextArea(5, 10)]
    [SerializeField] protected string content;

    [Tooltip("淡入淡出时间")]
    [SerializeField] protected float fadeDuration;

    [Tooltip("语句显示时间")]
    [SerializeField] protected float showTime;

    protected virtual void DoWait()
    {
        Continue();
    }
    public override void OnEnter()
    {
        DialogBox.Instance.Say(content, fadeDuration, showTime);
        Invoke("DoWait", showTime + fadeDuration);
    }
    public override string GetSummary()
    {
        return "\"" + content + "\"";
    }
}
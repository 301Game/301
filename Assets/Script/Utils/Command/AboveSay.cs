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

    public override void OnEnter()
    {
        DialogBox.Instance.Say(content, fadeDuration, showTime);
        Invoke("Continue", showTime);
    }
    public override string GetSummary()
    {
        return "\"" + content + "\"";
    }
}
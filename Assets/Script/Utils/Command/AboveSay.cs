using UnityEngine;
using Fungus;

[CommandInfo("Other",
             "AboveSay",
             "The dialog show above the character")]
[AddComponentMenu("")]
public class AboveSay : Command
{
    [Tooltip("Ҫ˵������")]
    [TextArea(5, 10)]
    [SerializeField] protected string content;

    [Tooltip("���뵭��ʱ��")]
    [SerializeField] protected float fadeDuration;

    [Tooltip("�����ʾʱ��")]
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
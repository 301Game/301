using System.Collections;
using UnityEngine;
using TMPro;
using Fungus;

/// <summary>
/// 管理人物头顶对话
/// Manage the dialog box above the character
/// </summary>
/// 
public class DialogBox : Singleton<DialogBox>
{
    private CanvasGroup dialogBoxCanvasGroup;
    [SerializeField]private TextMeshProUGUI dialogText;
    private float m_fadeDuration;
    protected override void Awake()
    {
        base.Awake();
        GetComponent<Canvas>().worldCamera = FindObjectOfType<Camera>();
        dialogBoxCanvasGroup = GetComponent<CanvasGroup>();
        dialogText = GetComponentInChildren<TextMeshProUGUI>();

        dialogBoxCanvasGroup.alpha = 0;
        dialogText.text = "";
    }

    public void Say(string content, float fadeDuration, float waitTime)
    {
        dialogText.SetText(content);
        m_fadeDuration = fadeDuration;
        LeanTween.value(0, 1, m_fadeDuration).setOnUpdate(
            (float updateAlpha) =>
            {
                dialogBoxCanvasGroup.alpha = updateAlpha;
            });

        Invoke("SayDialogFadeOut", waitTime);
    }
    private void SayDialogFadeOut()
    {
        LeanTween.value(1, 0, m_fadeDuration).setOnUpdate(
           (float updateAlpha) =>
           {
               dialogBoxCanvasGroup.alpha = updateAlpha;
           }).setOnComplete(() =>
           {
               dialogText.text = "";
           });
    }
}

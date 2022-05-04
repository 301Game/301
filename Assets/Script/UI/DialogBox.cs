using System.Collections;
using UnityEngine;
using TMPro;
using Fungus;

/// <summary>
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

    /// <summary>
    /// say.
    /// </summary>
    /// <param name="content">Speak content </param>
    /// <param name="fadeDuration">The content fade in and fade out time</param>
    /// <param name="waitTime">The time of the content's show time</param>
    public void Say(string content, float fadeDuration, float waitTime)
    {
        dialogText.SetText(content);
        Debug.Log("设置文本成功");
        m_fadeDuration = fadeDuration;
        LeanTween.value(0, 1, m_fadeDuration).setOnUpdate(
            (float updateAlpha) =>
            {
                dialogBoxCanvasGroup.alpha = updateAlpha;
                Debug.Log(dialogText.text);
            });

        Invoke("SayDialogFadeOut", waitTime);
    }
    /// <summary>
    /// fade out the sayDialog.
    /// </summary>
    private void SayDialogFadeOut()
    {
        Debug.Log("开始淡出");
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

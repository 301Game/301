using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class CGFader: SceneFader
{
    public bool isShow;
    IEnumerator ShowCoroutine(float time)
    {
        yield return StartCoroutine(FadeOut(time));
        isShow = true;
    }

    public IEnumerator HideCoroutine(float time)
    {

        yield return StartCoroutine(FadeInWithoutDestory(time));  
    }

    //public void Show(float time, GameObject obj)
    //{
    //    addChild(obj);
    //    GameManager.Instance.isMenuStopped = true;
    //    StartCoroutine(ShowCoroutine(time));
    //}
    public void Show(float time = 0.25f)
    {
        StartCoroutine(ShowCoroutine(time));
    }
    public void ShowDefault()
    {
        Show();
    }

    public void Hide(float time = 0.25f)
    {
        isShow = false;
        StartCoroutine(HideCoroutine(time));  
    }

    public void addChild(GameObject child)
    {
        Instantiate(child, transform);
    }
}

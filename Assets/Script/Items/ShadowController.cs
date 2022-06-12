using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowController : MonoBehaviour
{
    public float duration = 1;
    public float max_alpha = 70;

    private SpriteRenderer targetImg;
    public void ShowFirst()
    {
        GameObject first_shadow = transform.GetChild(0).gameObject;
        SpriteRenderer img = first_shadow.GetComponent<SpriteRenderer>();
        targetImg = img;
        img.color = new Color(0, 0, 0, 0);
        first_shadow.SetActive(true);
        FadeIn();
        Invoke("FadeOut", duration);
        Invoke("FadeIn", duration * 2);
    }
    public void ChangeToNext()
    {

    }
    
    private void FadeIn()
    {
        if (targetImg == null) return;
        LeanTween.value(0, max_alpha / 255, duration).setOnUpdate(
           (float alpha) =>
           {
               targetImg.color = new Color(0, 0, 0, alpha);
               Debug.Log("FadeIn");
           });
    }

    private void FadeOut()
    {
        if (targetImg == null) return;
        LeanTween.value(max_alpha / 255, 0, duration).setOnUpdate(
           (float alpha) =>
           {
               targetImg.color = new Color(0, 0, 0, alpha);
               Debug.Log("FadeOut");
           });
    }
}

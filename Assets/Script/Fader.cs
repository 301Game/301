using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    [Header("узуж")]
    [SerializeField] private float alpha;

   
    public IEnumerator FadeIn(Image target)
    {
        alpha = 1;

        while (alpha > 0)
        {
            alpha -= Time.deltaTime * 0.5f;
            target.color = new Color(target.color.r, target.color.g, target.color.b, alpha);
            yield return new WaitForSeconds(0);
        }
    }

    public IEnumerator FadeOut(Image target)
    {
        alpha = 0;
        while (alpha < 1)
        {
            alpha += Time.deltaTime * 0.5f;
            target.color = new Color(target.color.r, target.color.g, target.color.b, alpha);
            yield return new WaitForSeconds(0);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CGFader: Fader
{
    public Image blackImage;
    public GameObject targetCG = null;
    bool isHiding = false; //��¼Fader״̬
    private void Update()
    {
        if(isHiding && targetCG.GetComponent<Image>().color.a < 1)
        {
            targetCG.SetActive(false);
            isHiding = false;
        }//����CGͼƬ��Դ
    }

    public void Show(GameObject CG)
    {
        targetCG = CG;
        targetCG.gameObject.SetActive(true);
        StartCoroutine(FadeOut(blackImage));
        StartCoroutine(FadeOut(targetCG.GetComponent<Image>()));
    }

    public void Hide()
    {
        isHiding = true;
        StartCoroutine(FadeIn(blackImage));
        StartCoroutine(FadeIn(targetCG.GetComponent<Image>()));
    }
}

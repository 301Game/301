using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : Fader
{
    public Image blackImage;
    private void Start()
    {
        StartCoroutine(FadeIn(blackImage));
    }

    public void FadeTo(string screenName)
    {
        StartCoroutine(FadeOut(blackImage));
        SceneManager.LoadScene(screenName);
    }
}

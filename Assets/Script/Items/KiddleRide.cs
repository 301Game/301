using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiddleRide : MonoBehaviour
{
    public float duration = 1f;
    private Animator animator;
    private float anim_speed = 0f;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        animator.speed = anim_speed;
        Stop();
    }
    public void Run()
    {
        if (animator != null) animator.SetBool("run", true);
        LeanTween.value(0f, 1f, duration).setOnUpdate((float speed) =>
        {
            animator.speed = speed;
        });
    }
    public void Stop()
    {
        if (animator != null) animator.SetBool("run", false);
    }
    private IEnumerator FadeRun()
    {
        float time = 0;
        while (anim_speed < 1)
        {
            anim_speed += time / duration;
            time += Time.deltaTime;
            animator.speed = anim_speed;
            yield return null;
        }
    }
}

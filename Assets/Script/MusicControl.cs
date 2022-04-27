using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//含有Toggle单选框组件
using UnityEngine.UI;
public class MusicControl : MonoBehaviour
{
    //用于控制声音的AudioSource组件
    private AudioSource bgmAudio;

    //BGM
    AudioClip bgmClip;

    //小音效
    AudioClip Clip;
     void Awake()
    {
        //在添加此脚本的对象中添加AudioSource组件
        bgmAudio = this.gameObject.GetComponent<AudioSource>();
        //设置循环播放
        bgmAudio.loop = true;
        //设置音量，区间在0-1之间
        bgmAudio.volume = 1.0f;
        //设置clip
        
        GameObject.Find("Toggle").GetComponent<Toggle>().onValueChanged.AddListener(bgmON_OFF);
        
    }
    void OnGUI()
    {
 
        //音量控制slider
        bgmAudio.volume = GUI.HorizontalSlider(new Rect(550, 17, 50, 20), bgmAudio.volume, 0.0f, 1.0f);

    }
    public void bgmON_OFF(bool IsOn)
    {
        if(IsOn==true)
        {
            bgmAudio.Play();
            print("kan");
        }
        else
        {
            bgmAudio.Stop();
            print("l");
        }
    }
}


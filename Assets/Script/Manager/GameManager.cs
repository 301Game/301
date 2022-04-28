using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Cinemachine;


public class GameManager : Singleton<GameManager>
{
    public PlayerStates playerStates;
   // private CinemachineVirtualCamera virtualCamera;

    public bool isMusicOn = true;
    public float musicVolume = 1f;

    public bool isAudioOn;
    public float audioVolume;
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    public void RegisterPlayer(PlayerStates player)
    {
        playerStates = player;

       // virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
     //   if(virtualCamera != null)
        {
            //�趨�������
          //  virtualCamera.Follow = playerStates.transform; 
        }
    }

    //public void InterEventBegin()
    //{
    //    menuEnable = false;
    //    characterMovable = false;
    //}
    //public void InterEventEnd()
    //{
    //    menuEnable = true;
    //    characterMovable = true;
    //}
    //public void menuOut()
    //{
    //    characterMovable = false;
    //    keyEnterEnable = false;
    //}

    //public void menuHide()
    //{
    //    characterMovable = true;
    //    keyEnterEnable = true;
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;



public class GameManager : Singleton<GameManager>
{
    public PlayerStates playerStates;
    

    public bool isMusicOn = true;
    public float musicVolume = 1f;

    public bool isAudioOn;
    public float audioVolume;

    private CinemachineVirtualCamera virtualCamera;
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    public void RegisterPlayer(PlayerStates player)
    {
        playerStates = player;

       virtualCamera = FindObjectOfType<CinemachineVirtualCamera>();
       if(virtualCamera != null)
        {
          virtualCamera.Follow = playerStates.transform; 
        }
    }
}

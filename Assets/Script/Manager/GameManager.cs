using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GameManager : Singleton<GameManager>
{
    public PlayerStates playerStates;
    public bool isMenuStopped;
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
            //设定相机跟随
            virtualCamera.Follow = playerStates.transform; 
        }
    }
}

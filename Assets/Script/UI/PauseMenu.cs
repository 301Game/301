using System;
using UnityEngine;
using Fungus;
using System.Collections.Generic;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused;

    public GameObject PauseMenuUI;
    private bool isEnable;

    //private static List<Type> SetSaveDisableWhenMenusShow = new List<Type>(new Type[] {
    //    typeof(MainMenu),
    //    typeof(TipsBook)
    //});
    private void Awake()
    {
    }
    private void OnEnable()
    {
        // when any block is executing the save button is disable
        BlockSignals.OnBlockStart += SetDisable ;
        BlockSignals.OnBlockEnd += SetEnable;

    }
    private void OnDisable()
    {
        //when block start the save button is enable;
        BlockSignals.OnBlockStart -= SetDisable;
        BlockSignals.OnBlockEnd -= SetEnable;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isEnable)
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Debug.Log("PauseMenu �����㲥End");
        MenuSignals.DoMenuEnd(this);
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        Debug.Log("PauseMenu �����㲥Show");
        MenuSignals.DoMenuShow(this);
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    public void OnSaveButtonClicked()
    {
        SavaManager.Instance.WriteSaveData();
    }

    public void OnLoadButtonClicked()
    {
        
    }
    private void SetEnable(Block block) {isEnable = true;}
    private void SetDisable(Block block) {isEnable = false; }
}

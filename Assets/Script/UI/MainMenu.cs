using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void OnStartButtonClicked()
    {
        Debug.Log("StartButtonClicked");
        SceneController.Instance.CreatNewGame();
        
    }
    public void EndGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    public void OnLoadButtonClicked()
    {
        SceneController.Instance.LoadGame();
        //GameManagerSignals.DoLoadGameLoaded();
    }

}

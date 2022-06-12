using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.SceneManagement;

/// <summary>
/// Manage the date on the process of the game, and write into file when user want.
/// </summary>
public class SavaManager : Singleton<SavaManager>
{
    public bool isWaitForLoadPlayerdata;
    public SavePointData gameData = new SavePointData();
    public string loadSceneName;

    /// <summary>
    /// The static storage path;
    /// </summary>
    public static string STORAGER_DIRECTORY
    {
        get { return Application.persistentDataPath; }
    }
    public static string AudioPath
    {
        get{ return STORAGER_DIRECTORY + "Audio.json";}
    }

    public string GetSavedPath()
    {
        return STORAGER_DIRECTORY + "/history.json";
    }
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }
    
    /// <summary>
    /// When transition among different scenes, save the old scene information and update some basic data
    /// like the name of the active scene.
    /// </summary>
    public void SaveStatusAndOldScene()
    {
        GameManagerSignals.DoSaveGame();
        gameData.Encode();
    }

    /// <summary>
    /// Save immediately and write into files.
    /// </summary>
    public void WriteSaveData()
    {
        SaveStatusAndOldScene();
        WriteJsonIntoFile(GetSavedPath(), JsonUtility.ToJson(gameData));
    }

    /// <summary>
    /// Load old Game.
    /// </summary>
    public void LoadOldGame()
    {
        string dataJson = ReadFileIntoJson(GetSavedPath());
        JsonUtility.FromJsonOverwrite(dataJson, gameData);
        gameData.Decode();
        
    }

    /// <summary>
    /// Load the data of the new Scene;
    /// </summary>
    public void LoadScene()
    {
        gameData.LoadSceneData();
    }

    
    public void CreateNewGameData()
    {
        //TODO:删除存档
    }

    /// <summary>
    /// write the JSON into files.
    /// </summary>
    /// <param name="fileLoc">The location of the file</param>
    /// <param name="content">The JSON format content</param>
    /// <returns></returns>
    private bool WriteJsonIntoFile(string fileLoc, string content)
    {
        if (content == null) return false;

        //make sure the dir exists
        System.IO.FileInfo file = new System.IO.FileInfo(fileLoc);
        file.Directory.Create();

        System.IO.File.WriteAllText(fileLoc, content);
        Debug.Log(fileLoc);
        return true;
    }
   
    /// <summary>
    /// read the JSON from files.
    /// </summary>
    /// <param name="fileLoc">The location of the file</param>
    /// <returns></returns>
    private string ReadFileIntoJson(string fileLoc)
    {
        string content = string.Empty;
        if (System.IO.File.Exists(fileLoc))
        {
            Debug.Log("找到存档！");
            content = System.IO.File.ReadAllText(fileLoc);
        }
        return content;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavaManager : Singleton<SavaManager>
{
    public bool isWaitForLoadPlayerdata;
    

    public static string STORAGER_DIRECTORY
    {
        get { return Application.persistentDataPath + "/301/"; }
    }
    public static string AudioPath
    {
        get{ return STORAGER_DIRECTORY + "Audio.json";}
    }
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }
    public string savedSceneName
    {
        get
        {
            if (PlayerPrefs.HasKey("sceneName"))
            {
                return PlayerPrefs.GetString("sceneName");
            }
            else
            {
                //FIXME: ����û�д浵�������쳣����(���翪ʼ����Ϸ�����絯��)
                return "livingRoom";
            }
        }
    }
    public void SaveObj(Object obj, string key)
    {
        var data = JsonUtility.ToJson(obj);
        PlayerPrefs.SetString(key, data);
        PlayerPrefs.Save();
    }

    public void LoadObj(Object obj, string key)
    {
        if (PlayerPrefs.HasKey(key) && obj != null)
        {
            JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(key), obj);
        }
    }
    public void SavePlayerData()
    {
        GameManager.Instance.playerStates.gameObject.GetComponent<PlayerController>()?.updateDataIntoStates();
        //SaveObj(GameManager.Instance.playerStates.gameData, GameManager.Instance.playerStates.gameData.name);
        PlayerPrefs.SetString("sceneName", SceneController.Instance.currentScene);
    }
    public void LoadPlayerData()
    {
        //LoadObj(GameManager.Instance.playerStates.gameData, GameManager.Instance.playerStates.gameData.name);
        isWaitForLoadPlayerdata = false;
    }

    public void CreateNewGameData()
    {
        PlayerPrefs.DeleteAll();
    }

    public static void SaveAudioSetting()
    {
        var musicSettingData = JsonUtility.ToJson(AudioManager.Instance.audioData);
        WriteJsonIntoFile(AudioPath, musicSettingData);
    }

    public static bool LoadAudioSetting()
    {
        var musicSettingData = ReadFileIntoJson(AudioPath);
        if(musicSettingData == string.Empty)
        {
            Debug.LogError("No Music Seting File Found");
            return false;
        }
        AudioManager.Instance.audioData = JsonUtility.FromJson<AudioData_SO>(musicSettingData);
        return true;
    }
    
    private static bool WriteJsonIntoFile(string fileLoc, string content)
    {
        if (content == null) return false;

        //make sure the dir exists
        System.IO.FileInfo file = new System.IO.FileInfo(fileLoc);
        file.Directory.Create();

        System.IO.File.WriteAllText(fileLoc, content);
        return true;
    }
    private static string ReadFileIntoJson(string fileLoc)
    {
        string content = string.Empty;
        if (System.IO.File.Exists(fileLoc))
        {
            content = System.IO.File.ReadAllText(fileLoc);
        }
        return content;
    }
}

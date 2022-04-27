using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavaManager : Singleton<SavaManager>
{
    public bool isWaitForLoadPlayerdata;
    public AudioData audioData;
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
    public void Save(Object obj, string key)
    {
        var data = JsonUtility.ToJson(obj);
        PlayerPrefs.SetString(key, data);
        PlayerPrefs.Save();
    }

    public void Load(Object obj, string key)
    {
        if (PlayerPrefs.HasKey(key) && obj != null)
        {
            JsonUtility.FromJsonOverwrite(PlayerPrefs.GetString(key), obj);
        }
    }
    public void SavePlayerData()
    {
        GameManager.Instance.playerStates.gameObject.GetComponent<PlayerController>()?.updateDataIntoStates();
        Save(GameManager.Instance.playerStates.gameData, GameManager.Instance.playerStates.gameData.name);
        PlayerPrefs.SetString("sceneName", SceneController.Instance.currentScene);
    }
    public void LoadPlayerData()
    {
        Load(GameManager.Instance.playerStates.gameData, GameManager.Instance.playerStates.gameData.name);
        isWaitForLoadPlayerdata = false;
    }

    public void CreateNewGameData()
    {
        PlayerPrefs.DeleteAll();
    }
}

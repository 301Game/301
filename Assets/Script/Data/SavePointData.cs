using Fungus;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SavePointData
{
    public List<SaveDataItem> saveDataItems = new List<SaveDataItem>();
    public List<SceneData> sceneDataSet =  new List<SceneData>();
    
    private SceneData getSceneData(string sceneName)
    {
        foreach(var scene in sceneDataSet)
        {
            if (scene.sceneName.Equals(sceneName))
            {
                return scene;
            }
        }
        return null;
    }
    public void Encode()
    {
        SaveData saveData = SavaManager.Instance.gameObject.GetComponent<SaveData>();
        saveDataItems.Clear();
        saveData.Encode(saveDataItems);
        string scene = SceneController.Instance.currentScene;
        if (scene.Equals(SceneController.START_SCENE)) return;
        SceneData sceneData = getSceneData(scene);
        if (sceneData == null) sceneDataSet.Add(new SceneData());
        else sceneData.Encode();
    }
    /// <summary>
    /// decode the save data and some base information is synchronized for loading game;
    /// </summary>
    public void Decode()
    {
        SaveData data = SavaManager.Instance.gameObject.GetComponent<SaveData>();
        data.Decode(saveDataItems);
    }

    /// <summary>
    /// load the data in the active scene.
    /// </summary>
    /// <returns></returns>
    public bool LoadSceneData()
    {
        string scene = SceneController.Instance.currentScene;
        SceneData sceneData = getSceneData(scene);
        if (sceneData == null) return false;
        else sceneData.Decode();

        SaveData.DecodeGlobalVariable(saveDataItems);
        return true;
    }
}

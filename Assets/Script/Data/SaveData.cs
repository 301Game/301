using UnityEngine.SceneManagement;
using UnityEngine;
using Fungus;
using System.Collections.Generic;

/// <summary>
/// The basic data set; 
/// The active Scene, player's position, tips book data and global variables in flowchart;
/// </summary>
public class SaveData:MonoBehaviour
{
    /// <summary>
    /// Static string for the key type
    /// </summary>
    private static string activeSceneKey = "activeSceneName";
    private static string playerStatesKey = "playerData";
    private static string tipsBookKey = "tipsBookData";

    /// <summary>
    /// The information about the GlobalVaribales in Funugs.Flowchart.
    /// </summary>
    public  static string GlobalVariableFlowChartName = "GlobalVariables";
    private static int GlobalVariableIndex = 3;

    /// <summary>
    /// The script Object, used to transition the data between the different scene;
    /// </summary>
    public PlayerData_SO playerData;
    

    /// <summary>
    /// Initialize the data should save
    /// </summary>
    /// <param name="saveDataItems">The list of data Item that contain the encode results</param>
    public void Encode(List<SaveDataItem> saveDataItems)
    {
        string sceneName = SceneController.Instance.currentScene;
        var sceneData = SaveDataItem.Create(activeSceneKey, sceneName);
        saveDataItems.Add(sceneData);

        if(playerData != null)
        {
            var playerDataItem = SaveDataItem.Create(playerStatesKey, JsonUtility.ToJson(playerData));
            saveDataItems.Add(playerDataItem);
        }

        var tipsBook = FindObjectOfType<TipsBook>();
        if(tipsBook != null)
        {
            var tipsData = SaveDataItem.Create(tipsBookKey, JsonUtility.ToJson(tipsBook.Tips));
            saveDataItems.Add(tipsData);
        }
        EncodeGlobalVariable(saveDataItems);
    }
    /// <summary>
    /// Synchronize the data back
    /// </summary>
    /// <param name="saveDataItems"></param>
    public void Decode(List<SaveDataItem> saveDataItems)
    {
        foreach(var item in saveDataItems)
        {
            if(item.DataType == activeSceneKey)
            {
                SavaManager.Instance.loadSceneName = item.Data;
            }
            else if(item.DataType == playerStatesKey)
            {
                if(playerData != null)
                {
                    JsonUtility.FromJsonOverwrite(item.Data, playerData);
                }
                else
                {
                    Debug.LogError("没找到PlayerStates");
                }
                
            }
            else if(item.DataType == tipsBookKey)
            {
                if (TipsBook.IsInitialized)
                {
                    JsonUtility.FromJsonOverwrite(item.Data, TipsBook.Instance.Tips);
                }
                else
                {
                    Debug.LogError("没找到TipsBook");
                }

                
            }
            else
            {
                DecodeGlobalVariable(saveDataItems);
            }

        }
    }

    /// <summary>
    /// Decode the GlobalVariables in Flowchart
    /// </summary>
    /// <param name="saveDataItems">The Date Set</param>
    /// <returns></returns>
    public static bool DecodeGlobalVariable(List<SaveDataItem> saveDataItems)
    {
        var tmp = GameObject.Find(GlobalVariableFlowChartName);
        if (tmp == null) return false;
        FlowchartData globalChartData = new FlowchartData();
        JsonUtility.FromJsonOverwrite(saveDataItems[GlobalVariableIndex].Data, globalChartData);
        FlowchartData.Decode(globalChartData);
        return true;
    }

    /// <summary>
    /// Get data from the GlobalVariables.
    /// </summary>
    /// <param name="saveDataItems">The Date Set</param>
    public static void EncodeGlobalVariable(List<SaveDataItem> saveDataItems)
    {
        var globalChart = GameObject.Find(GlobalVariableFlowChartName);
        var globalItems = SaveDataItem.Create(globalChart.name,
        JsonUtility.ToJson(FlowchartData.Encode(globalChart.GetComponent<Flowchart>())));
        saveDataItems.Add(globalItems);
    }

}


using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using Fungus;

[System.Serializable]
public class SceneData
{
    public string sceneName;
    public List<FlowchartData> flowchartData = new List<FlowchartData>();
    public List<TagData> tagData = new List<TagData>();

    public SceneData()
    {
        Encode();
    }

    public void Encode()
    {
        sceneName = SceneController.Instance.currentScene;
        var flowcharts = GameObject.FindObjectsOfType<Flowchart>();
        foreach(var item in flowcharts)
        {
            if (item.name.Equals(SaveData.GlobalVariableFlowChartName)) continue;
            flowchartData.Add(FlowchartData.Encode(item));
        }

        var items = GameObject.FindObjectsOfType<ItemController>();
        foreach(var item in items)
        {
            tagData.Add(TagData.Encode(item.gameObject));
        }
    }
    public void Decode()
    {
        foreach (var itemData in flowchartData)
        {
            FlowchartData.Decode(itemData);
        }
        foreach(var tag in tagData)
        {
            TagData.Decode(tag);
        }
    }

}

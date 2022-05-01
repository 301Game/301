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
    }
    public void Decode()
    {
        foreach (var itemData in flowchartData)
        {
            FlowchartData.Decode(itemData);
        }
        
    }

}

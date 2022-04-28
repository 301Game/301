using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class MySaveData : SaveData
{
    protected const string TipsBookDataKey = "TipsBookDataKey";


    public override void Encode(List<SaveDataItem> saveDataItems)
    {
        base.Encode(saveDataItems);

        var tipsBookData = FindObjectOfType<TipsBook>().tipsBookData;

        var tipsDataItem = SaveDataItem.Create(TipsBookDataKey, JsonUtility.ToJson(tipsBookData));
        saveDataItems.Add(tipsDataItem);
    }

    public override void Decode(List<SaveDataItem> saveDataItems)
    {
        for (int i = 0; i < saveDataItems.Count; i++)
        {
            var saveDataItem = saveDataItems[i];
            if (saveDataItem == null)
            {
                continue;
            }

            if (saveDataItem.DataType == FlowchartDataKey)
            {
                var flowchartData = JsonUtility.FromJson<FlowchartData>(saveDataItem.Data);
                if (flowchartData == null)
                {
                    Debug.LogError("Failed to decode Flowchart save data item");
                    return;
                }

                FlowchartData.Decode(flowchartData);
            }

            if (saveDataItem.DataType == NarrativeLogKey)
            {
                FungusManager.Instance.NarrativeLog.LoadHistory(saveDataItem.Data);
            }

            if (saveDataItem.DataType == TipsBookDataKey)
            {
                var tipsBookData = JsonUtility.FromJson<TipsBookData_SO>(saveDataItem.Data);
                if (tipsBookData == null)
                {
                    Debug.LogError("Failed to decode TipsBook save data item");
                    return;
                }

                TipsBook.Instance.tipsBookData = tipsBookData;
            }
        }
    }
}


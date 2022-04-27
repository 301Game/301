using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Tips Book Data, the list of ItemData
/// </summary>
/// 
[System.Serializable]
[CreateAssetMenu(fileName = "New TipsBook", menuName = "New TipsBook Data")]
public class TipsBookData_SO : ScriptableObject
{
    public List<ItemData_SO> items;

    /// <summary>
    /// Add item into List and avoid the duplicate Item
    /// </summary>
    /// <param name="newItem">item to add</param>
    public void AddItem(ItemData_SO newItem)
    {
        foreach(var item in items)
        {
            if(item == newItem)
            {
                return;
            }
        }
        items.Add(newItem);
    }
}

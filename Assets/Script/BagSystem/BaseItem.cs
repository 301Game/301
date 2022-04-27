using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItem 
{
    // Start is called before the first frame update
    public BaseItem(int id, string name, int capacity, string icon, string des)
    {
        ID = id;
        Name = name;
        Capacity = capacity;
        Icon = icon;
        Des = des;
    }
    public int ID { get; protected set; }
    /// <summary>
    /// 物品名称
    /// </summary>
    public string Name { get; protected set; }
    /// <summary>
    /// 容量: 每个格子能够容纳该物品的数量
    /// </summary>
    public int Capacity { get; protected set; }
    /// <summary>
    /// 图标路径
    /// </summary>
    public string Icon { get; protected set; }
    /// <summary>
    /// 物品描述
    /// </summary>
    public string Des { get; protected set; }

    // Update is called once per frame
}

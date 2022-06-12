using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class TagData 
{
    public string objName;
    public string objTag;

    public static TagData Encode(GameObject obj)
    {
        TagData res = new TagData();
        res.objName = obj.name;
        res.objTag = obj.tag;
        return res;
    }

    public static void Decode(TagData data)
    {
        GameObject obj = GameObject.Find(data.objName);
        if (obj == null) return;
        obj.tag = data.objTag;

        
    }
}

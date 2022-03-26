
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName ="New Data", menuName = "Game Data/New data")]
public class GameData: ScriptableObject
{
    //人物位置信息
    public float[] position;
    public bool lookAtRight;//人物朝向，true为朝向右；
}


using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName ="New Data", menuName = "Game Data/New data")]
public class PlayerData_SO: ScriptableObject
{
    public float[] position;
    public bool lookAtRight;
}

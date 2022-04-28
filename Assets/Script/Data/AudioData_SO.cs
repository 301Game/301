
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "New data", menuName = "Music Data/New data")]
public class AudioData_SO : ScriptableObject
{
    public bool isMusicOn;
    public float musicVolume; 
    public bool isAudioOn;
    public float audioVolume;
}

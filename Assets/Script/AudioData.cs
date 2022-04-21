
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "New data", menuName = "Music Data/New data")]
public class ScriptableObject1 : ScriptableObject
{
    public AudioSource audioSource;
    public bool isMusicOn;
    public float musicVolume;
}

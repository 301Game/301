
using UnityEngine;


[System.Serializable]
public class GameData
{
    public string sceneName;
    public int sceneIndex;
    public float[] position;

    public GameData(PlayerController player)
    {
        sceneName = player.theSceneName;
        sceneIndex = player.theSceneIndex;
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;
    }
}

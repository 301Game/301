using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entrance : MonoBehaviour
{
    public enum entranceType{
        LEFT,
        MIDDLE,
        RIGHT,
        GAME_ENTRANCE,
        ANY,
    }
    public string fromScene;
    public entranceType type;
    // Start is called before the first frame update
    void Start()
    {
        //if(PlayerController.instance.lastSceneName == fromScene)
        //{
        //    CameraController.instance.transform.position = new Vector3(this.transform.position.x,
        //        CameraController.instance.transform.position.y,
        //        CameraController.instance.transform.position.z);
        //    PlayerController.instance.transform.position = new Vector3(this.transform.position.x,
        //        PlayerController.instance.transform.position.y,
        //        PlayerController.instance.transform.position.z);
        //}
    }
}

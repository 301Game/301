using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : ItemController
{
    public string trasitionSceneName;
    public Entrance.entranceType destinationType;

    private void Update()
    {
        if(hasPlayer && Input.GetKeyDown(KeyCode.F))
        {
            SceneController.Instance.TransitionToDestination(trasitionSceneName, destinationType);
            Debug.Log("destination:" + destinationType);
        }
    }
}

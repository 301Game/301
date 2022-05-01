using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : ItemController
{
    public string trasitionSceneName;
    public Entrance.EntranceType destinationType;

    private void Awake()
    {
        interKeyEvents.AddListener(Transition);
    }
    private void Transition()
    {
        SceneController.Instance.TransitionToDestination(trasitionSceneName, destinationType);
        Debug.Log("destination:" + destinationType);
    }
}

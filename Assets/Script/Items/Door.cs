using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class Door : ItemController
{
    public string trasitionSceneName;
    public Entrance.EntranceType destinationType;

    [Tooltip("Whether Auto transition to the desination or not")]
    [SerializeField]protected bool autoTransition = true;

    protected virtual void Awake()
    {
        if(autoTransition)interKeyEvents.AddListener(Transition);
    }
    public void Transition()
    {
        SceneController.Instance.TransitionToDestination(trasitionSceneName, destinationType);
        Debug.Log("destination:" + destinationType);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Fungus;
using UnityEngine.Serialization;

public enum IconType
{
    DOOR,
    SEARCH,
}
public class ItemController : MonoBehaviour
{
    public GameObject tipIconPrefab;

    protected bool hasPlayer;
    public ItemData_SO itemData;
    public IconType iconType;

    [FormerlySerializedAs("OnEnterKeyDown")]
    [SerializeField]
    protected UnityEvent enterEvents = new UnityEvent();

    [FormerlySerializedAs("onInterKeyDown")]
    [SerializeField]
    protected UnityEvent interKeyEvents = new UnityEvent();
    protected void OnEnable()
    {
        //GameManagerSignals.OnSaveGame += SaveTag;
        //GameManagerSignals.OnLoadGameLoaded += GetTag;
    }

    protected void OnDisable()
    {
        //GameManagerSignals.OnSaveGame -= SaveTag;
        //GameManagerSignals.OnLoadGameLoaded -= GetTag;
    }
    protected void OnTriggerEnter2D(Collider2D collision)
    {
       if (enterEvents != null) enterEvents.Invoke();
    }

    public void AddItem()
    {
        if(itemData != null)
        {
            Debug.Log("addItem");
            Debug.Log(TipsBook.IsInitialized);
            TipsBook.Instance.AddItem(itemData);
        }
    }

    private bool isInteractive()
    {
        if (PauseMenu.gameIsPaused) return false;
        if (TipsBook.Instance.isActive) return false;
       foreach(var chart in FindObjectsOfType<Flowchart>())
        {
           if (chart.HasExecutingBlocks()) return false;
        }
        return true;
 
    }

    public void Interact()
    {
        interKeyEvents.Invoke();
    }

    public void SwitchToInter()
    {
        gameObject.tag = "Interactive";
    }
   
    public void SwitchToUninter()
    {
        gameObject.tag = "Untagged";
    }
}
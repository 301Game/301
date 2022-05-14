using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Fungus;
using UnityEngine.Serialization;

public class ItemController : MonoBehaviour
{
    public GameObject tipIconPrefab;

    protected bool hasPlayer;
    private GameObject tipIcon;
    public ItemData_SO itemData;

    [FormerlySerializedAs("OnEnterKeyDown")]
    [SerializeField]
    protected UnityEvent enterEvents = new UnityEvent();

    [FormerlySerializedAs("onInterKeyDown")]
    [SerializeField]
    protected UnityEvent interKeyEvents = new UnityEvent();


    protected void OnTriggerExit2D(Collider2D collision)
    {
        hasPlayer = false;
        Destroy(tipIcon);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(tipIconPrefab != null) 
                tipIcon = Instantiate(tipIconPrefab, new Vector2(transform.position.x, 0.5f), Quaternion.identity, transform);
        
            hasPlayer = true;
            if (enterEvents != null) enterEvents.Invoke();
        }
        
    }

    protected void Update()
    {
        if (hasPlayer && Input.GetKeyDown(KeyCode.F) && isInteractive())
        {
            interKeyEvents.Invoke();
        }
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
}
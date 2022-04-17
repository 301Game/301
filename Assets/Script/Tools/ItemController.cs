using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Fungus;
using UnityEngine.Serialization;

public class ItemController : MonoBehaviour
{
    public GameObject tipIconPrefab;
    public CGFader CGManager;

    [SerializeField]protected bool hasPlayer;
    GameObject tipIcon;

    [FormerlySerializedAs("onInterKayDown")]
    [SerializeField]
    protected UnityEvent interKeyEvents = new UnityEvent();
    //声明用于多播的委托


    protected void OnTriggerExit2D(Collider2D collision)
    {
        hasPlayer = false;
        Destroy(tipIcon);
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            tipIcon = Instantiate(tipIconPrefab, new Vector2(transform.position.x, 0.5f), Quaternion.identity, transform);
            hasPlayer = true;
        }
    }

    protected void Update()
    {
        if (hasPlayer && Input.GetKeyDown(KeyCode.F) && !PauseMenuManager.gameIsPaused)
        {
            interKeyEvents.Invoke();
            //GameManager.Instance.InterEventEnd();
        }

        //if (hasPlayer && Input.GetKeyDown(KeyCode.Escape))
        //{

        //}
    }
    //当摁下交互键
    //protected void FirstTriggerEvent() {
    //    firstTrigger = false;
    //    Debug.Log(gameObject.name + ":FirstTriggerEvent");
    //    if (firstBlockName.Length == 0)
    //    {
    //        Debug.LogError(gameObject.name + ":没有设置首次触发时的block参数");
    //        return;
    //    }
    //    if (flowchart.HasBlock(firstBlockName))
    //    {
    //        flowchart.ExecuteBlock(firstBlockName);
    //    }
    //    else
    //    {
    //        Debug.LogError(gameObject.name + ":没有找到首次触发的block,请检查是否拼写正确");
    //    }
    //}
    //protected void OtherTriggerEvent() {
    //    if (otherBlockName.Length == 0)
    //    {
    //        Debug.LogError(gameObject.name + ":没有设置再次/多次触发时的block参数");
    //        return;
    //    }
    //    if (flowchart.HasBlock(otherBlockName))
    //    {
    //        flowchart.ExecuteBlock(otherBlockName);
    //    }
    //    else
    //    {
    //        Debug.LogError(gameObject.name + ":没有找到再次/多次触发的block,请检查是否拼写正确");
    //    }
    //}
}
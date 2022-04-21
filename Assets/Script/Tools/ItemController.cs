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
    //�������ڶಥ��ί��


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
    //�����½�����
    //protected void FirstTriggerEvent() {
    //    firstTrigger = false;
    //    Debug.Log(gameObject.name + ":FirstTriggerEvent");
    //    if (firstBlockName.Length == 0)
    //    {
    //        Debug.LogError(gameObject.name + ":û�������״δ���ʱ��block����");
    //        return;
    //    }
    //    if (flowchart.HasBlock(firstBlockName))
    //    {
    //        flowchart.ExecuteBlock(firstBlockName);
    //    }
    //    else
    //    {
    //        Debug.LogError(gameObject.name + ":û���ҵ��״δ�����block,�����Ƿ�ƴд��ȷ");
    //    }
    //}
    //protected void OtherTriggerEvent() {
    //    if (otherBlockName.Length == 0)
    //    {
    //        Debug.LogError(gameObject.name + ":û�������ٴ�/��δ���ʱ��block����");
    //        return;
    //    }
    //    if (flowchart.HasBlock(otherBlockName))
    //    {
    //        flowchart.ExecuteBlock(otherBlockName);
    //    }
    //    else
    //    {
    //        Debug.LogError(gameObject.name + ":û���ҵ��ٴ�/��δ�����block,�����Ƿ�ƴд��ȷ");
    //    }
    //}
}
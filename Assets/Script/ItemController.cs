using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public GameObject tipIconPrefab;
    GameObject tipIcon;

    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(tipIcon);
        /*
         * 留用于设置调查图标的消失
         */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            Debug.Log("接触碰撞检测");
            tipIcon = Instantiate(tipIconPrefab, new Vector2(transform.position.x, 0.5f), Quaternion.identity, transform);
            attachEvent();
            /*
             * 后续可主要用于部分素材的调查图标显示，用于提示玩家可探索内容，不建议用于条件触发
             */

        }
    }

    public void attachEvent() {
    
    }
    public void enterEvent() {
    
    }
}
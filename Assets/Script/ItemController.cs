using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        /*
         * 留用于设置调查图标的消失
         */
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {

            Debug.Log("接触碰撞检测");
            /*
             * 后续可主要用于部分素材的调查图标显示，用于提示玩家可探索内容，不建议用于条件触发
             */
            if (Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("摁键检测");
                /*
                 * 设置flag，防止游戏剧情中玩家再次点击导致剧情重新播放
                 */
            }
        }
    }
}
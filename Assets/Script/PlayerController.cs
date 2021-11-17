using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//鎺у埗瑙掕壊
public class PlayController : MonoBehaviour
{
    public float speed = 0.1f;//移动速度
    Rigidbody2D rigidbody2d;
    float horizontal;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        // Start is called before the first frame update
    }
    // Update is called once per frame`
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
    }


    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + 3.0f * horizontal * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("接触离开检测");
        /*
         * 留用于设置调查图标的消失
         */
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("碰撞进入检测");
        float moveX = Input.GetAxisRaw("Horizontal");//鎺у埗姘村钩绉诲姩鏂瑰悜AD
        float moveY = Input.GetAxisRaw("Vertical");//鎺у埗鍨傜洿绉诲姩鏂瑰悜WS

        Vector2 position = transform.position;
        position.x += moveX * speed * Time.deltaTime;
        position.y += moveY * speed * Time.deltaTime;
        transform.position = position;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 0.1f;//移动速度
    Rigidbody2D rigidbody2d;
    float horizontal;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
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

    void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("碰撞进入检测");
    }
}

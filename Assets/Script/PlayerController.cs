using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//鎺у埗瑙掕壊
public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    float speed = 2f;//移动速度
    bool is_move = false;// 人物移动状态
    int direction = 0; //-1表示向左， 1表示向右
    float horizontal;
 

    Rigidbody2D rigidbody2d;
    Animator animator;

    //将游戏玩家设计为单例
    private void Awake()
    {
        if (instance == null) instance = this;
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        // Start is called before the first frame update
    }
    // Update is called once per frame`
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        //Debug.Log("horizontal:" + horizontal);
        Debug.Log("speed:" + speed);
        //判断人物是否移动
        if (Mathf.Abs(horizontal) < 0.0000001f)
        {
            animator.SetFloat("speed", 0.0f);
            is_move = false;
        }
        else
        {
            animator.SetFloat("speed", 1.0f);
            is_move = true;
            //判断人物移动方向
            if (horizontal > 0)
            {
                animator.SetFloat("direction", 1.0f);
                direction = 1;
            }
            else
            {
                animator.SetFloat("direction", -1.0f);
                direction = -1;
            }
        }

        
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        if (!is_move) return;
        position.x = position.x + speed * direction * Time.deltaTime;
        rigidbody2d.MovePosition(position);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        //Debug.Log("接触离开检测");
        /*
         * 留用于设置调查图标的消失
         */
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        //Debug.Log("碰撞进入检测");
        //float moveX = Input.GetAxisRaw("Horizontal");//鎺у埗姘村钩绉诲姩鏂瑰悜AD
        //float moveY = Input.GetAxisRaw("Vertical");//鎺у埗鍨傜洿绉诲姩鏂瑰悜WS

        //Vector2 position = transform.position;
        //position.x += moveX * speed * Time.deltaTime;
        //position.y += moveY * speed * Time.deltaTime;
        //transform.position = position;
    }
}
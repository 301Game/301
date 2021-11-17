using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//控制角色
public class PlayController : MonoBehaviour
{
    public float speed = 0.1f;//�ƶ��ٶ�
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
        Debug.Log("�Ӵ��뿪���");
        /*
         * ���������õ���ͼ�����ʧ
         */
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("��ײ������");
        float moveX = Input.GetAxisRaw("Horizontal");//控制水平移动方向AD
        float moveY = Input.GetAxisRaw("Vertical");//控制垂直移动方向WS

        Vector2 position = transform.position;
        position.x += moveX * speed * Time.deltaTime;
        position.y += moveY * speed * Time.deltaTime;
        transform.position = position;
    }
}
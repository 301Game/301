using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//控制角色
public class characterchange : MonoBehaviour
{
    public float speed = 5f;//移动速度
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame`
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");//控制水平移动方向AD
        float moveY = Input.GetAxisRaw("Vertical");//控制垂直移动方向WS

        Vector2 position = transform.position;
        position.x += moveX * speed * Time.deltaTime;
        position.y += moveY * speed * Time.deltaTime;
        transform.position = position;



    }
}
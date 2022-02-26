using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//鎺у埗瑙掕壊
public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;//单例

    public string lastSceneName;

    float speed = 0.05f;//移动速度

    bool is_move = false;// 人物移动状态

    int direction = 0; //-1表示向左， 1表示向右

    float horizontal;
 

    Rigidbody2D rigidbody2d;
    Animator animator;

    public GameObject tipIcon;

    //将游戏玩家设计为单例
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
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
        position.x = position.x + speed * direction;
        rigidbody2d.MovePosition(position);
    }
    public void ShowTipIcon(Transform target)
    {
        tipIcon.transform.position = new Vector2(target.position.x, 0.5f);
        tipIcon.SetActive(true);
    }

    public void HideTipIcon()
    {
        tipIcon.SetActive(false);
    }
}
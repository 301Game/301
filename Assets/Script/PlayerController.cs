using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//控制角色
public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;//����

    public string lastSceneName;

    float speed = 0.05f;//�ƶ��ٶ�

    bool is_move = false;// �����ƶ�״̬

    int direction = 0; //-1��ʾ���� 1��ʾ����

    float horizontal;
 

    Rigidbody2D rigidbody2d;
    Animator animator;

    public GameObject tipIcon;

    //����Ϸ������Ϊ����
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

        //�ж������Ƿ��ƶ�
        if (Mathf.Abs(horizontal) < 0.0000001f)
        {
            animator.SetFloat("speed", 0.0f);
            is_move = false;
        }
        else
        {
            animator.SetFloat("speed", 1.0f);
            is_move = true;
            //�ж������ƶ�����
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
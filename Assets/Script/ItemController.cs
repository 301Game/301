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
         * ���������õ���ͼ�����ʧ
         */
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerController player = collision.gameObject.GetComponent<PlayerController>();
        if (player != null)
        {

            Debug.Log("�Ӵ���ײ���");
            /*
             * ��������Ҫ���ڲ����زĵĵ���ͼ����ʾ��������ʾ��ҿ�̽�����ݣ�������������������
             */
            if (Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("�������");
                /*
                 * ����flag����ֹ��Ϸ����������ٴε�����¾������²���
                 */
            }
        }
    }
}
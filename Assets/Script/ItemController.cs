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
         * ���������õ���ͼ�����ʧ
         */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            Debug.Log("�Ӵ���ײ���");
            tipIcon = Instantiate(tipIconPrefab, new Vector2(transform.position.x, 0.5f), Quaternion.identity, transform);
            attachEvent();
            /*
             * ��������Ҫ���ڲ����زĵĵ���ͼ����ʾ��������ʾ��ҿ�̽�����ݣ�������������������
             */

        }
    }

    public void attachEvent() {
    
    }
    public void enterEvent() {
    
    }
}
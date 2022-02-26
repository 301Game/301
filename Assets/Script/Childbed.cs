using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Childbed : MonoBehaviour
{
    public Image ticket;
    private bool isHide = true;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.F) && !ticket.gameObject.activeSelf)
        {
            ticket.gameObject.SetActive(true);
            ticket.transform.parent.gameObject.SetActive(true);
        }//Í¼Æ¬ÎªÒþ²Ø×´Ì¬Ê±¼ì²âÞô½¡ÞôÏÂ×´Ì¬

        if (Input.GetKey(KeyCode.Escape) && ticket.gameObject.activeSelf){
            ticket.transform.parent.gameObject.SetActive(false);
            ticket.gameObject.SetActive(false);
        }
    }
}

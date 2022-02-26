using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Childbed : ItemController
{
    public GameObject ticket;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKey(KeyCode.F) && !ticket.gameObject.activeSelf)
        {
            Debug.Log("Press F");
            ticket.transform.parent.GetComponent<CGFader>().Show(ticket);  
        }//Í¼Æ¬ÎªÒþ²Ø×´Ì¬Ê±¼ì²âÞô½¡ÞôÏÂ×´Ì¬

        if (Input.GetKey(KeyCode.Escape) && ticket.gameObject.activeSelf)
        {
            Debug.Log("Press ESC");
            ticket.transform.parent.GetComponent<CGFader>().Hide();
        }

    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    PlayerController.instance.ShowTipIcon(transform);
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    PlayerController.instance.HideTipIcon();
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public GameObject tipIconPrefab;
    public CGFader CGManager;
    protected bool hasPlayer;
    GameObject tipIcon;

    private void OnTriggerExit2D(Collider2D collision)
    {
        hasPlayer = false;
        Destroy(tipIcon);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            tipIcon = Instantiate(tipIconPrefab, new Vector2(transform.position.x, 0.5f), Quaternion.identity, transform);
            hasPlayer = true;
            attachEvent();
        }
    }

    public void attachEvent() {
        
    }
    public void enterEvent() {
    
    }
}
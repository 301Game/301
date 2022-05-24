using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMenuController : MonoBehaviour
{
    public GameObject mainPanel;
    public void Resume()
    {
        if (mainPanel == null) return;
        mainPanel.SetActive(true);
        MenuSignals.DoMenuShow(this);
    }

    public void Hide()
    {
        if (mainPanel == null) return;
        mainPanel.SetActive(false);
        MenuSignals.DoMenuEnd(this);
    }
}

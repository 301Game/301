using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class RadioPassword : MonoBehaviour
{
    private GameObject buttonNumPanel;
    private GameObject RadioPanel;
    private GameObject numberPanel;

    private Button[] buttons=new Button[12];
    private TextMeshProUGUI[] numbers = new TextMeshProUGUI[4];
    private string m_targetBlock;
    private string m_booleanVar;

    private void Awake()
    {
        if (buttonNumPanel == null | RadioPanel == null)Debug.LogError("组件不存在");
        RadioPanel = transform.GetChild(0).gameObject;
        for (int i = 0; i < 4; i++)
        {
            numbers[i] = numberPanel.transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>();
            buttons[i] = buttonNumPanel.transform.GetChild(i).GetComponent<Button>();
        }
    }

    public void Register(string block, string relevant_var)
    {
        m_targetBlock = block;
        m_booleanVar = relevant_var;
    }
}

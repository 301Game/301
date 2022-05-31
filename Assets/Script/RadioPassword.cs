using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class RadioPassword : MonoBehaviour
{

    public string targetPassword;
    public GameObject mainPanel;

    private string m_targetBlock;
    private string m_booleanVar;
    private string curPassword;

    public void OnNumBtnClicked(int btnNum)
    {
        curPassword += btnNum.ToString();
    }
    public void OnPlayBtnClicked()
    {
        if(curPassword.Equals(targetPassword))
        {
            Hide();
            var flows = FindObjectsOfType<Fungus.Flowchart>();
            foreach (var flow in flows)
            {
                if (flow.HasBlock(m_targetBlock))
                {
                    flow.SetBooleanVariable(m_booleanVar, true);
                    flow.ExecuteBlock(m_targetBlock);
                    break;
                }
            }
        }

        curPassword = "";
    }

    public void Hide()
    {
        MenuSignals.DoMenuEnd(this);
        mainPanel.SetActive(false);
    }
    public void Show()
    {
        MenuSignals.DoMenuShow(this);
        mainPanel.SetActive(true);
    }
    public void OnEndBtnClicked()
    {
        curPassword = "";
    }

    public void Register(string block, string relevant_var)
    {
        m_targetBlock = block;
        m_booleanVar = relevant_var;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PasswordLock : MonoBehaviour
{
    public GameObject numberPanel;
    public GameObject buttonUpPanel;
    public GameObject buttonDownPanel;
    public string targetPassword;

    private string m_targetBlock;
    private string m_booleanVar;
    private GameObject mainPanel;
    private TextMeshProUGUI[] numbers = new TextMeshProUGUI[4];
    private Button[] buttonUps = new Button[4];
    private Button[] buttonDowns = new Button[4];
    private void Awake()
    {
        if (numberPanel == null | buttonDownPanel == null || buttonUpPanel == null) Debug.LogError("���������ò�����");
        mainPanel = transform.GetChild(0).gameObject;
        for (int i = 0; i < 4; i++)
        {
            numbers[i] = numberPanel.transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>();
            buttonUps[i] = buttonUpPanel.transform.GetChild(i).GetComponent<Button>();
            buttonDowns[i] = buttonDownPanel.transform.GetChild(i).GetComponent<Button>();
        }
    }
    public void Register(string block, string relevant_var)
    {
        m_targetBlock = block;
        m_booleanVar = relevant_var;
    }
    public void OnBtnUpClicked(int btnIndex)
    {
        int curNum = getCurNum(btnIndex);
        if (curNum == -1) return;
        setNum(btnIndex, curNum + 1);

    }

    public void OnBtnDownClicked(int btnIndex)
    {
        int curNum = getCurNum(btnIndex);
        if (curNum == -1) return;
        setNum(btnIndex, curNum - 1);
    }

    public void OnBtnSureClicked()
    {
        if(m_targetBlock.Length == 0 || m_booleanVar.Length == 0)
        {
            Debug.LogError("������δ���¼������");
            return;
        }
        string curStr = "";
        for(int i = 0; i < 4; i++)
        {
            curStr += numbers[i].text;
        }
        if (curStr.Equals(targetPassword))
        {
            Hide();
            var flows = FindObjectsOfType<Fungus.Flowchart>();
            foreach (var flow in flows) {
                if (flow.HasBlock(m_targetBlock))
                {
                    flow.SetBooleanVariable(m_booleanVar, true);
                    flow.ExecuteBlock(m_targetBlock);
                    break;
                }
            }
        }

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
    private int getCurNum(int btnIndex)
    {
        if (btnIndex < 0 || btnIndex > 3)
        {
            Debug.LogError("The btnIndex " + btnIndex + " is illegal");
            return -1;
        }
        Debug.Log(numbers[btnIndex].text);
        int curNum = int.Parse(numbers[btnIndex].text);
        return curNum;
    }
    private void setNum(int btnIndex, int setNum)
    {
        if (btnIndex < 0 || btnIndex > 3)
        {
            Debug.LogError("The btnIndex is illegal");
            return;
        }

        if (setNum < 0) numbers[btnIndex].SetText("9");
        else if (setNum > 9) numbers[btnIndex].SetText("0");
        else numbers[btnIndex].SetText(setNum.ToString());
    }
}

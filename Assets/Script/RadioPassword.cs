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

    private Button[] numbuttons=new Button[10];
    private InputField field;
    private string m_targetBlock;
    private string m_booleanVar;

    private void Awake()
    {
     
    }
    public void clickdelete()
    {
        if (field.text.Trim().Length != 0 || !field.text.Equals(""))
            field.text = field.text.Remove(field.text.Trim().Length - 1, 1);
    }
    public void click0()
    {
        if(field.text.Trim().Length<=4)
        field.text += "0";
    }
    public void click1()
    {
        if (field.text.Trim().Length <= 4)
            field.text += "1";
    }
    public void click2()
    {
        if (field.text.Trim().Length <= 4)
            field.text += "2";
    }
    public void click3()
    {
        if (field.text.Trim().Length <= 4)
            field.text += "3";
    }
    public void click4()
    {
        if (field.text.Trim().Length <= 4)
            field.text += "4";
    }
    public void click5()
    {
        if (field.text.Trim().Length <= 4)
            field.text += "5";
    }
    public void click6()
    {
        if (field.text.Trim().Length <= 4)
            field.text += "6";
    }
    public void click7()
    {
        if (field.text.Trim().Length <= 4)
            field.text += "7";
    }
    public void click8()
    {
        if (field.text.Trim().Length <= 4)
            field.text += "8";
    }
    public void click9()
    {
        if (field.text.Trim().Length <= 4)
            field.text += "9";
    }
    public void Register(string block, string relevant_var)
    {
        m_targetBlock = block;
        m_booleanVar = relevant_var;
    }
}

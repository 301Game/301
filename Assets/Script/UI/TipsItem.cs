using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TipsItem : MonoBehaviour
{
    public ItemData_SO item;

    private TextMeshProUGUI title;
    private Button button;
    private TipsBook tipsBook;

    private void Start()
    {
        title = GetComponentInChildren<TextMeshProUGUI>();
        button = GetComponent<Button>();
        tipsBook = transform.root.GetComponent<TipsBook>();

        if(item != null) title.text = item.ItemTitle;

    }
    public void UpdateBoard()
    {
        
        tipsBook.UpdateBoardInf(item);
    }
}

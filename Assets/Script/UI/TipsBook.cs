using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Fungus;

public class TipsBook : Singleton<TipsBook>
{
    public TipsBookData_SO tipsBookData;
    public GameObject mainPanel;
    public GameObject tipBtn;
    public GameObject ItemList;
    public TextMeshProUGUI ItemInfText;
    public Image ItemInfImg;
    public GameObject ItemPrefab;

    public bool isActive;

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    private void Update()
    {
        bool flag = true;
        foreach (var chart in FindObjectsOfType<Flowchart>())
        {
            if (chart.HasExecutingBlocks())
            {
                flag = false;
                break;
            }

        }
        tipBtn.SetActive(flag);
    }
    public void AddItem(ItemData_SO newItem)
    {
        tipsBookData.AddItem(newItem);
        Instantiate(ItemPrefab, ItemList.transform).GetComponent<TipsItem>().item = newItem;
    }
    public void UpdateBoardInf(ItemData_SO item)
    {
        if (item == null) return;
        ItemInfText.text = item.ItemDesc;
        ItemInfImg.enabled = true;
        ItemInfImg.sprite = item.ItemImg;
        ItemInfImg.SetNativeSize();
    }

    public void Resume()
    {
        mainPanel.SetActive(true);
        tipBtn.SetActive(false);
        isActive = true;
    }

    public void Hide()
    {
        mainPanel.SetActive(false);
        tipBtn.SetActive(true);
        isActive = false;
    }
    
    
}

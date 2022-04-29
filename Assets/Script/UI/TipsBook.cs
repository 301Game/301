using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Fungus;

public class TipsBook : Singleton<TipsBook>
{
    public TipsBookData_SO template_tipsBookData;
    
    public GameObject mainPanel;
    public GameObject tipBtn;
    public GameObject ItemList;
    public TextMeshProUGUI ItemInfText;
    public Image ItemInfImg;
    public GameObject ItemPrefab;

    public bool isActive;

    private TipsBookData_SO tipsBookData;
  
    public TipsBookData_SO Tips { get { return tipsBookData; } set { tipsBookData = value; } }
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
        
    }
    private void Update()
    {
    }
    private void OnEnable()
    {
        if (template_tipsBookData == null) Debug.Log("template is null");
        tipsBookData = Instantiate(template_tipsBookData);
        GameManagerSignals.OnNewGameStart += InitTipsBookUI;
        GameManagerSignals.OnLoadGameLoaded += InitTipsBookUI;
    }
    private void OnDisable()
    {
        GameManagerSignals.OnNewGameStart -= InitTipsBookUI;
        GameManagerSignals.OnLoadGameLoaded -= InitTipsBookUI;
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
    
    private void InitTipsBookUI()
    {
        foreach (var item in tipsBookData.items)
        {
            AddItem(item);
        }
        tipBtn.SetActive(true);
    }

}

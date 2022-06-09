using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Fungus;

public class TipsBook : Singleton<TipsBook>
{
    
    public GameObject mainPanel;
    public GameObject tipBtn;
    public GameObject ItemList;
    public TextMeshProUGUI ItemInfText;
    public Image ItemInfImg;
    public GameObject ItemPrefab;

    public bool isActive;
    private const float imgHeight = 300f;
    private TipsBookData tipsBookData = new TipsBookData();
  
    public TipsBookData Tips { get { return tipsBookData; } set { tipsBookData = value; } }
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

        if (item.ItemImg == null) ItemInfImg.enabled = false;
        else
        {
            int raw_width = item.ItemImg.texture.width;
            int raw_height = item.ItemImg.texture.height;
            ItemInfImg.sprite = item.ItemImg;
            float scaling = raw_height / imgHeight;
            float imgWidth = raw_width / scaling;
            ItemInfImg.rectTransform.sizeDelta = new Vector2(imgWidth, imgHeight);
            
        }
        
    }

    public void Resume()
    {
        MenuSignals.DoMenuShow(this);
        mainPanel.SetActive(true);
        tipBtn.SetActive(false);
        isActive = true;
    }

    public void Hide()
    {
        MenuSignals.DoMenuEnd(this);
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

using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(PlayerStates))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerController : Singleton<PlayerController>
{
    private static List<System.Type> SetUnMovable = new List<System.Type>(new System.Type[]{
        typeof(PauseMenu),
        typeof(TipsBook),
        typeof(PasswordLock),
        typeof(SimpleMenuController),
        typeof(RadioPassword),
    });

    private List<GameObject> targetObj = new List<GameObject>();
    private GameObject iconRoot;
    private float player_speed = 0.05f;
    private int direction = 0;
    private float horizontal;
    private bool isMovable = true;
    private int moveableLockNum = 0;
    #region animator control variables
    [SerializeField]private float anim_speed;
    private float anim_direction;
    #endregion 

    #region components
    private Rigidbody2D rigidbody2d;
    private Animator animator;
    private PlayerStates playerStates;
    #endregion
    public PlayerStates playerData
    {
        get
        {
            updateDataIntoStates();
            return playerStates;
        }
        set
        {
            playerStates = value;
            loadPlayerData();
        }
    }
    
    protected override void Awake()
    {
        base.Awake();
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerStates = GetComponent<PlayerStates>();
        iconRoot = transform.Find("TipIcon").gameObject;

    }
    void OnEnable()
    {
        GameManager.Instance.RegisterPlayer(playerStates);

        GameManagerSignals.OnSaveGame += updateDataIntoStates;
        GameManagerSignals.OnLoadGameLoaded += loadPlayerData;
        Fungus.BlockSignals.OnBlockStart += SetUnmovable;
        Fungus.BlockSignals.OnBlockEnd += SetMoable;
        MenuSignals.OnMenuShow += SetUnmovable;
        MenuSignals.OnMenuEnd += SetMovable;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interactive"))
        {
            targetObj.Insert(0, collision.gameObject);
            updateIcon();
        }
    }

    protected void OnTriggerExit2D(Collider2D collision)
    {
        targetObj.Remove(collision.gameObject);
        updateIcon();
    }
    private void OnDisable()
    {
        GameManagerSignals.OnSaveGame -= updateDataIntoStates;
        GameManagerSignals.OnLoadGameLoaded -= loadPlayerData;
        Fungus.BlockSignals.OnBlockStart -= SetUnmovable;
        Fungus.BlockSignals.OnBlockEnd -= SetMoable;
        MenuSignals.OnMenuShow -= SetUnmovable;
        MenuSignals.OnMenuEnd -= SetMovable;
    }

    //get the key enter
    void Update()
    {
        if (!isMoveable()) return;
        horizontal = Input.GetAxis("Horizontal");
        if (Mathf.Approximately(horizontal, 0)) anim_speed = 0;
        else anim_speed = 1;

        if (horizontal > 0) anim_direction = 1;
        else if(horizontal < 0)anim_direction = -1;
        // horizontal = 0 play stop keep the last direction

        UpdateAnimation();
        if(targetObj.Count > 0 && Input.GetKeyDown(KeyCode.F))
        {
            targetObj[0].GetComponent<ItemController>()?.Interact();
        }
    }

    //player move
    void FixedUpdate()
    {
        if (!isMoveable()) return;
        Vector2 position = rigidbody2d.position;
        position.x = position.x + player_speed * anim_direction * anim_speed;
        rigidbody2d.MovePosition(position);
    }

    private void UpdateAnimation()
    {
        animator.SetFloat("speed", anim_speed);
        animator.SetFloat("direction", anim_direction);
    }

    public void updateDataIntoStates()
    {
        float[] position = new float[3];
        position[0] = transform.position.x;
        position[1] = transform.position.y;
        position[2] = transform.position.z;
        playerStates.position = position;
        //playerStates.lookAtRight = direction > 0 ? true: false;
    }
    public void loadPlayerData()
    {

        transform.position = new Vector3(playerStates.position[0], playerStates.position[1], playerStates.position[2]);
    }

    private void StopAnimation()
    {
        animator.SetFloat("speed", 0f);
    }

    private void SetUnmovable(Fungus.Block block)
    {
        Debug.Log("Block "+ block.BlockName + " 广播,人物不可移动锁+1");
        AddMovableLock();
    }
    private void SetMoable(Fungus.Block block)
    {
        Debug.Log("Block" + block.BlockName + " 广播,人物不可移动锁-1");
        ReduceMovableLock();
    }
    private bool isMoveable()
    {
        return moveableLockNum <= 0;
    }
    private void AddMovableLock()
    {
        moveableLockNum++;
        StopAnimation();
    }
    private void ReduceMovableLock()
    {
        moveableLockNum--;
    }
    private void SetUnmovable(MonoBehaviour menu)
    {
        Debug.Log("Menu广播,人物不可移动锁+1");
        if (SetUnMovable.Contains(menu.GetType())){
            AddMovableLock();
        }
    }

    private void SetMovable(MonoBehaviour menu)
    {
        Debug.Log("人物可移动，人物可移动锁-1");
        if (SetUnMovable.Contains(menu.GetType()))
        {
            ReduceMovableLock();
        }
        
    }

    public void updateIcon()
    {
        if (targetObj.Count == 0) {
            hideAllIcon();
            return;
        }
        showIcon(targetObj[0].GetComponent<ItemController>()?.iconType);
    }
    private void showIcon(IconType? type)
    {
        if (type == null) return;
        hideAllIcon();
        switch (type)
        {
            case IconType.DOOR:
                iconRoot.transform.GetChild(0).gameObject.SetActive(true);
                break;
            case IconType.SEARCH:
                iconRoot.transform.GetChild(1).gameObject.SetActive(true);
                break;
        }
    }

    public void hideAllIcon()
    {
        int iconNum = iconRoot.transform.childCount;
        for(int n = 0; n < iconNum; n++)
        {
            iconRoot.transform.GetChild(n).gameObject.SetActive(false);
        }
    }
}
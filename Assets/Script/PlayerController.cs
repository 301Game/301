using UnityEngine.SceneManagement;
using UnityEngine;
using Fungus;
//鎺у埗瑙掕壊
public class PlayerController : Singleton<PlayerController>
{
    public static PlayerController instance;//单例

    public string lastSceneName;
    public string theSceneName;
    public int theSceneIndex;

    private float speed = 0.05f;//移动速度

    private bool is_move = false;// 人物移动状态

    private int direction = 0; //-1表示向左， 1表示向右

    private float horizontal;

    private Rigidbody2D rigidbody2d;
    private Animator animator;
    
    [SerializeField]private PlayerStates playerStates;

    private Flowchart flowchart;
    //private PauseMenuManager pauseMenu;
    //将游戏玩家设计为单例
    protected override void Awake()
    {
        base.Awake();
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerStates = GetComponent<PlayerStates>();

        flowchart = GameObject.Find("Flowchart").GetComponent<Flowchart>();
        //pauseMenu = GameObject.Find("Menu UI").GetComponent<PauseMenuManager>();
       
    }
    void OnEnable()
    {
        Debug.Log(GameManager.IsInitialized);
        GameManager.Instance.RegisterPlayer(playerStates);
        if (SavaManager.Instance.isWaitForLoadPlayerdata)
        {
            //读取存档
            SavaManager.Instance.LoadPlayerData();
            //将数据状态同步到gameObject上
            loadPlayerData();
        }
    }
    void Start()
    {
    }

    void Update()
    {
        if (!isMovable())
        {
            StopAnimation();
            return;
        }
        horizontal = Input.GetAxis("Horizontal");

        //判断人物是否移动
        if (Mathf.Abs(horizontal) < 0.0000001f)
        {
            animator.SetFloat("speed", 0.0f);
            is_move = false;
        }
        else
        {
            animator.SetFloat("speed", 1.0f);
            is_move = true;
            //判断人物移动方向
            if (horizontal > 0)
            {
                animator.SetFloat("direction", 1.0f);
                direction = 1;
            }
            else
            {
                animator.SetFloat("direction", -1.0f);
                direction = -1;
            }
        }

        
    }

    void FixedUpdate()
    {
        if (isMovable())
        {
            Vector2 position = rigidbody2d.position;
            if (!is_move) return;
            position.x = position.x + speed * direction;
            rigidbody2d.MovePosition(position);
        }   
    }

    //public void Save()
    //{
    //    Scene theScene = SceneManager.GetActiveScene();
    //    theSceneName = theScene.name;
    //    theSceneIndex = theScene.buildIndex;

    //    SaveLoadSystem.SaveData(this);
    //}

    //public void Load()
    //{
    //    GameData data = SaveLoadSystem.LoadData();
    //    Vector3 position;
    //    position.x = data.position[0];
    //    position.y = data.position[1];
    //    position.z = data.position[2];
    //}
    public void updateDataIntoStates()
    {
        playerStates.position[0] = transform.position.x;
        playerStates.position[1] = transform.position.y;
        playerStates.position[2] = transform.position.z;
        playerStates.lookAtRight = direction > 0 ? true: false;
    }
    public void loadPlayerData()
    {
        transform.position = new Vector3(playerStates.position[0], playerStates.position[1], playerStates.position[2]);
        //if(playerStates.lookAtRight) 
    }

    private void StopAnimation()
    {
        animator.SetFloat("speed", 0f);
    }
    private void OnGUI()
    {

    }
    private bool isMovable()
    {
        if (flowchart.HasExecutingBlocks()) return false;
        if (PauseMenuManager.gameIsPaused) return false;
        return true;
    }
}
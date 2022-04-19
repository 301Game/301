using UnityEngine.SceneManagement;
using UnityEngine;
//æŽ§åˆ¶è§’è‰²
public class PlayerController : Singleton<PlayerController>
{
    public static PlayerController instance;//ï¿½ï¿½ï¿½ï¿½

    public string lastSceneName;
<<<<<<< HEAD
    float speed = 0.05f;//ï¿½Æ¶ï¿½ï¿½Ù¶ï¿½
    bool is_move = false;// ï¿½ï¿½ï¿½ï¿½ï¿½Æ¶ï¿½×´Ì¬
    int direction = 0; //-1ï¿½ï¿½Ê¾ï¿½ï¿½ï¿½ï¿½ 1ï¿½ï¿½Ê¾ï¿½ï¿½ï¿½ï¿½
    float horizontal;
 
=======
    public string theSceneName;
    public int theSceneIndex;
>>>>>>> 6a2961bf43932d4cca3c65abd53f59f2d30d3831

    private float speed = 0.05f;//ÒÆ¶¯ËÙ¶È

    private bool is_move = false;// ÈËÎïÒÆ¶¯×´Ì¬

    private int direction = 0; //-1±íÊ¾Ïò×ó£¬ 1±íÊ¾ÏòÓÒ

    private float horizontal;


    private Rigidbody2D rigidbody2d;
    private Animator animator;
    
    [SerializeField]private PlayerStates playerStates;

<<<<<<< HEAD
    //ï¿½ï¿½ï¿½ï¿½Ï·ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½Îªï¿½ï¿½ï¿½ï¿½
    private void Awake()
=======
    //½«ÓÎÏ·Íæ¼ÒÉè¼ÆÎªµ¥Àý
    protected override void Awake()
>>>>>>> 6a2961bf43932d4cca3c65abd53f59f2d30d3831
    {
        base.Awake();
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        playerStates = GetComponent<PlayerStates>();
       
    }
    void OnEnable()
    {
        GameManager.Instance.RegisterPlayer(playerStates);
        if (SavaManager.Instance.isWaitForLoadPlayerdata)
        {
            //¶ÁÈ¡´æµµ
            SavaManager.Instance.LoadPlayerData();
            //½«Êý¾Ý×´Ì¬Í¬²½µ½gameObjectÉÏ
            loadPlayerData();
        }
    }
    void Start()
    {
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        //ï¿½Ð¶ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½Ç·ï¿½ï¿½Æ¶ï¿½
        if (Mathf.Abs(horizontal) < 0.0000001f)
        {
            animator.SetFloat("speed", 0.0f);
            is_move = false;
        }
        else
        {
            animator.SetFloat("speed", 1.0f);
            is_move = true;
            //ï¿½Ð¶ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½Æ¶ï¿½ï¿½ï¿½ï¿½ï¿½
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
        Vector2 position = rigidbody2d.position;
        if (!is_move) return;
        position.x = position.x + speed * direction;
        rigidbody2d.MovePosition(position);
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
<<<<<<< HEAD
        //Debug.Log("ï¿½Ó´ï¿½ï¿½ë¿ªï¿½ï¿½ï¿½");
        /*
         * ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½Ãµï¿½ï¿½ï¿½Í¼ï¿½ï¿½ï¿½ï¿½ï¿½Ê§
         */
=======
        playerStates.position[0] = transform.position.x;
        playerStates.position[1] = transform.position.y;
        playerStates.position[2] = transform.position.z;
        playerStates.lookAtRight = direction > 0 ? true: false;
>>>>>>> 6a2961bf43932d4cca3c65abd53f59f2d30d3831
    }
    public void loadPlayerData()
    {
<<<<<<< HEAD
        //Debug.Log("ï¿½ï¿½×²ï¿½ï¿½ï¿½ï¿½ï¿½ï¿½");
        //float moveX = Input.GetAxisRaw("Horizontal");//æŽ§åˆ¶æ°´å¹³ç§»åŠ¨æ–¹å‘AD
        //float moveY = Input.GetAxisRaw("Vertical");//æŽ§åˆ¶åž‚ç›´ç§»åŠ¨æ–¹å‘WS

        //Vector2 position = transform.position;
        //position.x += moveX * speed * Time.deltaTime;
        //position.y += moveY * speed * Time.deltaTime;
        //transform.position = position;
=======
        transform.position = new Vector3(playerStates.position[0], playerStates.position[1], playerStates.position[2]);
        //if(playerStates.lookAtRight) 
>>>>>>> 6a2961bf43932d4cca3c65abd53f59f2d30d3831
    }
}
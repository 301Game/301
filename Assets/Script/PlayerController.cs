using UnityEngine.SceneManagement;
using UnityEngine;
//using Fungus;
//控制角色
public class PlayerController : Singleton<PlayerController>
{
    public static PlayerController instance;

    public string lastSceneName;
    float speed = 0.05f;
    bool is_move = false;
    int direction = 0;
    float horizontal;
 
    public string theSceneName;
    public int theSceneIndex;


    private Rigidbody2D rigidbody2d;
    private Animator animator;
    
    [SerializeField]public PlayerStates playerStates;
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
       // flowchart = FindObjectOfType<Flowchart>();
       
    }
    void OnEnable()
    {
        GameManager.Instance.RegisterPlayer(playerStates);

        GameManagerSignals.OnSaveGame += updateDataIntoStates;
        GameManagerSignals.OnLoadGameLoaded += loadPlayerData;
    }
    void Start()
    {
    }

    private void OnDisable()
    {
        GameManagerSignals.OnSaveGame -= updateDataIntoStates;
        GameManagerSignals.OnLoadGameLoaded -= loadPlayerData;
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        if (Mathf.Abs(horizontal) < 0.0000001f)
        {
            animator.SetFloat("speed", 0.0f);
            is_move = false;
        }
        else
        {
            animator.SetFloat("speed", 1.0f);
            is_move = true;
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
    public void updateDataIntoStates()
    {
        float[] position = new float[3];
        position[0] = transform.position.x;
        position[1] = transform.position.y;
        position[2] = transform.position.z;
        playerStates.position = position;
        playerStates.lookAtRight = direction > 0 ? true: false;
    }
    public void loadPlayerData()
    {

        transform.position = new Vector3(playerStates.position[0], playerStates.position[1], playerStates.position[2]);
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
      //  if (flowchart.HasExecutingBlocks()) return false;
        if (PauseMenu.gameIsPaused) return false;
        if(TipsBook.IsInitialized && TipsBook.Instance.isActive) return false;
        
        return true;
    }
}
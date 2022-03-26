using UnityEngine.SceneManagement;
using UnityEngine;
//控制角色
public class PlayerController : Singleton<PlayerController>
{
    public static PlayerController instance;//����

    public string lastSceneName;
    public string theSceneName;
    public int theSceneIndex;

    private float speed = 0.05f;//�ƶ��ٶ�

    private bool is_move = false;// �����ƶ�״̬

    private int direction = 0; //-1��ʾ���� 1��ʾ����

    private float horizontal;


    private Rigidbody2D rigidbody2d;
    private Animator animator;
    
    [SerializeField]private PlayerStates playerStates;

    //����Ϸ������Ϊ����
    protected override void Awake()
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
            SavaManager.Instance.LoadPlayerData();
            loadPlayerData();
        }
    }
    void Start()
    {
        
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");

        //�ж������Ƿ��ƶ�
        if (Mathf.Abs(horizontal) < 0.0000001f)
        {
            animator.SetFloat("speed", 0.0f);
            is_move = false;
        }
        else
        {
            animator.SetFloat("speed", 1.0f);
            is_move = true;
            //�ж������ƶ�����
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
}
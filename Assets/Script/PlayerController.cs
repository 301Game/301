using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;
//using Fungus;
//控制角色
public class PlayerController : Singleton<PlayerController>
{

    private static List<System.Type> SetUnMovable = new List<System.Type>(new System.Type[]{
        typeof(PauseMenu),
        typeof(TipsBook),
    });
    private float speed = 0.05f;
    private bool is_move = false;
    private int direction = 0;
    private float horizontal;
    private bool isMovable;


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
        Fungus.BlockSignals.OnBlockStart += SetUnmovable;
        Fungus.BlockSignals.OnBlockEnd += SetMoable;
        MenuSignals.OnMenuShow += SetUnmovable;
        MenuSignals.OnMenuEnd += SetMovable;
    }
    void Start()
    {
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

    void Update()
    {
        if (!isMovable) return;
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
        if (!isMovable) return;
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
    //private bool isMovable()
    //{
    //  //  if (flowchart.HasExecutingBlocks()) return false;
    //    if (PauseMenu.gameIsPaused) return false;
    //    if(TipsBook.IsInitialized && TipsBook.Instance.isActive) return false;
        
    //    return true;
    //}
    private void SetUnmovable(Fungus.Block block)
    {
        isMovable = false;
        StopAnimation();
    }
    private void SetMoable(Fungus.Block block)
    {
        isMovable = true;
    }

    private void SetUnmovable(MonoBehaviour menu)
    {
        if (SetUnMovable.Contains(menu.GetType())){
            isMovable = false;
            StopAnimation();
        }
    }

    private void SetMovable(MonoBehaviour menu)
    {
        isMovable = true;
    }
}
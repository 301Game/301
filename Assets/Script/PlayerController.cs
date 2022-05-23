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
    });
    private float player_speed = 0.05f;
    private int direction = 0;
    private float horizontal;
    private bool isMovable = true;

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

    //get the key enter
    void Update()
    {
        if (!isMovable) return;
        horizontal = Input.GetAxis("Horizontal");
        if (Mathf.Approximately(horizontal, 0)) anim_speed = 0;
        else anim_speed = 1;

        if (horizontal > 0) anim_direction = 1;
        else anim_direction = -1;

        UpdateAnimation();
    }

    //player move
    void FixedUpdate()
    {
        if (!isMovable) return;
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
        isMovable = false;
        StopAnimation();
    }
    private void SetMoable(Fungus.Block block)
    {
        isMovable = true;
    }

    private void SetUnmovable(MonoBehaviour menu)
    {
        Debug.Log("Menu广播");
        if (SetUnMovable.Contains(menu.GetType())){
            Debug.Log("人物不可移动");
            isMovable = false;
            StopAnimation();
        }
    }

    private void SetMovable(MonoBehaviour menu)
    {
        Debug.Log("人物可移动");
        isMovable = true;
    }
}
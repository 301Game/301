
using UnityEngine;
//using Fungus;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused;

    public GameObject PauseMenuUI;

  //  private Flowchart flowchart;
    private void Awake()
    {
<<<<<<< HEAD
       // flowchart = GameObject.Find("Flowchart")?.GetComponent<Flowchart>();
=======
        flowchart = FindObjectOfType<Flowchart>();
>>>>>>> 31250ed53f52372a7c75f07793310e1f6e474f8c
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isShowable())
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void Pause()
    {
        
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }
    public void OnSaveButtonClicked()
    {
        SavaManager.Instance.WriteSaveData();
    }

    public void OnLoadButtonClicked()
    {
        
    }
    private bool isShowable()
    {
       // if (flowchart.HasExecutingBlocks()) return false;
        if (TipsBook.Instance.isActive) return false;
        return true;
    }
}

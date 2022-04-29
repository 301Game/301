
using UnityEngine;
using Fungus;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused;

    public GameObject PauseMenuUI;

    private Flowchart flowchart;
    private void Awake()
    {
        flowchart = FindObjectOfType<Flowchart>();
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
        if (flowchart.HasExecutingBlocks()) return false;
        if (TipsBook.Instance.isActive) return false;
        return true;
    }
}

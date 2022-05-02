using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manage the scene transition.
/// </summary>
public class SceneController : Singleton<SceneController>
{
    public GameObject playerPrefab;
    public SceneFader faderPrefab;

    public const string START_SCENE = "Start";
    public const string FIRST_SCENE = "clinic";

    private bool isLoading = false;
    public string currentScene
    {
        get
        {
            return SceneManager.GetActiveScene().name;
        }
    }
    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(this);
    }

    /// <summary>
    /// Transition to destination.
    /// </summary>
    /// <param name="sceneName">The desination scene</param>
    /// <param name="type">The entrance type in the destination scene</param>
    public void TransitionToDestination(string sceneName, Entrance.EntranceType type)
    {
        
        StartCoroutine(TransitionScene(sceneName,type));
    }

    /// <summary>
    /// Start a new Game
    /// </summary>
    public void CreatNewGame()
    {
        SavaManager.Instance.CreateNewGameData();
        GameManagerSignals.DoNewGameStart();
        StartCoroutine(TransitionScene(FIRST_SCENE, Entrance.EntranceType.GAME_ENTRANCE));
        
    }

    /// <summary>
    /// Load an old game.
    /// </summary>
    public void LoadGame()
    {
        
        SavaManager.Instance.LoadOldGame();
        isLoading = true;
        StartCoroutine(TransitionScene(SavaManager.Instance.loadSceneName, Entrance.EntranceType.ANY));
    }

    /// <summary>
    /// Transition to the new scene and locate the player in the certain type door;
    /// </summary>
    /// <param name="sceneName">The desination</param>
    /// <param name="type">the type of entrance in the new scene</param>
    /// <returns></returns>
    private IEnumerator TransitionScene(string sceneName, Entrance.EntranceType type)
    {
        SceneFader fader = Instantiate(faderPrefab);
        yield return StartCoroutine(fader.FadeOut(1.0f));
        SavaManager.Instance.SaveStatusAndOldScene(); //TODO:save the old scene data;
        yield return SceneManager.LoadSceneAsync(sceneName);
        SavaManager.Instance.LoadScene(); //TODO:load the new scene data if exists;
        GameObject destinationEntrance = GetDestination(type);

        var players = FindObjectOfType<PlayerController>();
        if (players != null) players.transform.position = destinationEntrance.transform.position;
        else yield return Instantiate(playerPrefab, destinationEntrance.transform.position, destinationEntrance.transform.rotation);

        if (isLoading) {
            GameManagerSignals.DoLoadGameLoaded();
            isLoading = false;
        }
        yield return StartCoroutine(fader.FadeIn(1.0f));
        yield break;
    }

    /// <summary>
    /// Find the target entrance.
    /// </summary>
    /// <param name="destinationType"></param>
    /// <returns></returns>
    private GameObject GetDestination(Entrance.EntranceType destinationType)
    {
        if (destinationType == Entrance.EntranceType.ANY) return FindObjectOfType<Entrance>().gameObject;
        Entrance[] targets = FindObjectsOfType<Entrance>();
        for (int i = 0; i < targets.Length; i++)
        {
            if(targets[i].type == destinationType)
            {
                Debug.Log("i:" + targets[i].type);
                return targets[i].gameObject;
            }
        }
        return null;
    }
}

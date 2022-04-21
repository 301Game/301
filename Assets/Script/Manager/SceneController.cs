using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : Singleton<SceneController>
{
    public GameObject playerPrefab;
    public SceneFader faderPrefab;

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
    public void TransitionToDestination(string sceneName, Entrance.entranceType type)
    {
        
        StartCoroutine(TransitionScene(sceneName,type));
    }

    public void CreatNewGame()
    {
        SavaManager.Instance.CreateNewGameData();
        StartCoroutine(TransitionScene("livingRoom", Entrance.entranceType.GAME_ENTRANCE));
    }

    public void LoadGame()
    {
        StartCoroutine(TransitionScene(SavaManager.Instance.savedSceneName, Entrance.entranceType.ANY));
        SavaManager.Instance.isWaitForLoadPlayerdata = true;
    }
    private IEnumerator TransitionScene(string sceneName, Entrance.entranceType type)
    {
        //TODO:��������
        //TODO:����Fader
        SceneFader fader = Instantiate(faderPrefab);
        yield return StartCoroutine(fader.FadeOut(1.0f));
        yield return SceneManager.LoadSceneAsync(sceneName);
        GameObject destinationEntrance = GetDestination(type);
        yield return Instantiate(playerPrefab, destinationEntrance.transform.position, destinationEntrance.transform.rotation);
        yield return StartCoroutine(fader.FadeIn(1.0f));
        yield break;
    }
    private GameObject GetDestination(Entrance.entranceType destinationType)
    {
        if (destinationType == Entrance.entranceType.ANY) return FindObjectOfType<Entrance>().gameObject;
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

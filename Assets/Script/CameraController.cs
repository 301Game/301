using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using Cinemachine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;
   // private CinemachineConfiner cameraConfiner;//�߽����

    //��¼��ǰ��������
    private Scene activeScene;
    [SerializeField] private GameObject confiner;
    [SerializeField] private string sceneName = "";

    private void Awake()
    {
        //if (instance == null) instance = this;
        //else
        //{
        //    Destroy(gameObject);
        //}
        //DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        //cameraConfiner = GetComponentInChildren<CinemachineConfiner>();
    }

    // Update is called once per frame
    void Update()
    {
        //����Ӧ�������߽��趨
        activeScene = SceneManager.GetActiveScene();
        if(sceneName == "" || sceneName != activeScene.name)
        {
            sceneName = activeScene.name;
            confiner = GameObject.FindWithTag("Confiner");
          //  cameraConfiner.m_BoundingShape2D = confiner.GetComponent<Collider2D>();
        }

    }
}

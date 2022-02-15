using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string sceneName;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKey(KeyCode.F))
        {
            if (other.tag == "Player")
            {
                PlayerController.instance.lastSceneName = SceneManager.GetActiveScene().name;
                //SceneManager.LoadScene(sceneName);
                FindObjectOfType<SceneFader>().FadeTo(sceneName);
            }
        }
    }
}

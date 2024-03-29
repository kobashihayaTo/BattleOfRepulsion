using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    string targetSceneName = "SampleScene";

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // SampleSceneに切り替える
            SceneManager.LoadScene("SampleScene");
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}

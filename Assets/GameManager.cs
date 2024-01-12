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
            // SampleSceneÇ…êÿÇËë÷Ç¶ÇÈ
            SceneManager.LoadScene("SampleScene");
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene(targetSceneName);
    }
}

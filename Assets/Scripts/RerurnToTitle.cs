using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RerurnToTitle : MonoBehaviour
{
    // ★追加
    public int timeCount;

    void Start()
    {

        // ★追加
        // 任意に設定した時間の経過後、「GoTitle」メソッドを呼び出す（ポイント）
        Invoke("GoTitle", timeCount);

    }

    // ★追加
    void GoTitle()
    {
        SceneManager.LoadScene("TitleScene");

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RerurnToTitle : MonoBehaviour
{
    // ���ǉ�
    public int timeCount;

    void Start()
    {

        // ���ǉ�
        // �C�ӂɐݒ肵�����Ԃ̌o�ߌ�A�uGoTitle�v���\�b�h���Ăяo���i�|�C���g�j
        Invoke("GoTitle", timeCount);

    }

    // ���ǉ�
    void GoTitle()
    {
        SceneManager.LoadScene("TitleScene");

    }
}

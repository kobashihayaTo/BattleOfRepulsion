using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewFPS : MonoBehaviour
{
    [SerializeField]
    private float Interval = 0.1f;

    private float _time_cnt;
    private int _frames;
    private float _time_mn;
    private float _fps;

    private void Start()
    {
        // FPS�̒l��ʂ̏ꏊ�Ŏw�肵�Ă���Ȃ�ȉ��̐ݒ�͏���
        Application.targetFrameRate = 60;

    }

    // FPS�̕\���ƌv�Z
    private void Update()
    {
        _time_mn -= Time.deltaTime;
        _time_cnt += Time.timeScale / Time.deltaTime;
        _frames++;

        if (0 < _time_mn) return;

        _fps = _time_cnt / _frames;
        _time_mn = Interval;
        _time_cnt = 0;
        _frames = 0;
    }
}
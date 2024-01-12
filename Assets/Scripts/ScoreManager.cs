using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int score = 0;
    private Text scoreLabel;

    void Start()
    {
        score = 0;
        scoreLabel = GameObject.Find("ScoreLabel").GetComponent<Text>();
        scoreLabel.text = "SCORE�F" + score;
    }

    // �X�R�A�𑝉������郁�\�b�h
    // �O������A�N�Z�X���邽��public�Œ�`����
    public void AddScore(int amount)
    {
        score += amount;
        scoreLabel.text = "SCORE�F" + score;
    }

    public static int Getscene()
    {
        return score;
    }
}

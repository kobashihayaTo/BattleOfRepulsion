using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class IntervalAttackTimer : MonoBehaviour
{

    public Text IntervalTimer;
    int interval;

    // Start is called before the first frame update
    void Start()
    {
        interval = PlayerMove.GetIntervalTimer();
        IntervalTimer.text = "IntervalTimerÅF" + interval;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}

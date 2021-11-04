using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerObserver : MonoBehaviour
{
    [SerializeField] private casesSO channel;
    [SerializeField] private float lostTime;
    private Timer timer_;

    private void Start()
    {
        timer_ = GetComponent<Timer>();
    }
    private void DecreaseTimer(int value)
    {
        if (value == 4 )
        {
            timer_.pretime = lostTime;
        }
    }
    
    private void OnEnable()
    {
        channel.OnJulianHit += DecreaseTimer;
    }

    private void OnDisable()
    {
        channel.OnJulianHit -= DecreaseTimer;
    }
}

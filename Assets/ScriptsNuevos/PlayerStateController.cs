using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateController : MonoBehaviour
{
    PlayerMovement move;
    [SerializeField]float lostSpeed = 0;
    [SerializeField] private casesSO channel;
    float temp;

    void Start()
    {
        move = GetComponent<PlayerMovement>();
        temp = move.speed;
    }

    private void OnEnable()
    {
        channel.OnJulianHit += StateMachine;
    }

    private void OnDisable()
    {
        channel.OnJulianHit -= StateMachine;
    }

    void StateMachine(int type)
    {
        switch (type)
        {
            case 1:
                Slow();
                break;
            case 2:
                Root();
                break;
            case 3:
                Drunk();
                break;

            default:
                break;
        }
    }

    void Slow()
    {
        move.speed = lostSpeed;
    }

    void Root()
    {
        move.speed = 0;
    }

    void Drunk()
    {
        move.speed = -temp;
    }
}

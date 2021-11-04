using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linterna : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private casesSO channel;
    [SerializeField] GameObject lantern;
    private void Blackout (int value) {

        if (value == 5)
        {
            lantern.SetActive(false);
        }
       
    }
    

    private void OnEnable()
    {
        channel.OnJulianHit += Blackout;
    }

    private void OnDisable()
    {
        channel.OnJulianHit -= Blackout;
    }
}

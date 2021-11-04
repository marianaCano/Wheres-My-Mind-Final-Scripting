using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoriaObserver : MonoBehaviour
{
    [SerializeField] private casesSO channel;
    
    [SerializeField] private Image winScreen = null;
    [SerializeField] GameObject timer = null;
    [SerializeField] GameObject player = null;

    void Victoria(int value)
    {
        if (value == 0)
        {
            player.GetComponent<PlayerMovement>().speed = 0;
            winScreen.gameObject.SetActive(true);
            timer.SetActive(false);
        }
        
    }
    
    private void OnEnable()
    {
        channel.OnJulianHit += Victoria;
    }

    private void OnDisable()
    {
        channel.OnJulianHit -= Victoria;
    }
    
    
}

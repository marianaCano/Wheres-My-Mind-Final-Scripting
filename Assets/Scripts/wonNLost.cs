using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class wonNLost : MonoBehaviour
{
    [SerializeField] Image winScreen = null, loseScreen = null;
    [SerializeField] GameObject timer = null;
    [SerializeField] GameObject player = null;
    bool motivated = false;

    void Update()
    {
        
        if (timer.GetComponent<Timer>().pretime <= 0 && winScreen.gameObject.activeSelf == false)
        {
            loseScreen.gameObject.SetActive(true);
            player.GetComponent<PlayerMovement>().speed = 0;
            timer.SetActive(false);
        }
        else if (motivated == true && loseScreen.gameObject.activeSelf == false)
        {
            player.GetComponent<PlayerMovement>().speed = 0;
            winScreen.gameObject.SetActive(true);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            motivated = true;
            timer.SetActive(false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
        [SerializeField] Text timeText = null;
        public float pretime = 0;

        void Update()
        {
            if (pretime <= 0)
                pretime = 0;
            TimerLogic();
        }
        void TimerLogic()
        {
            pretime -= Time.deltaTime;
            if (pretime > 60)
            {
                float secTime = (int)pretime % 60;
                float minTime;

                if (secTime >= 30)
                    minTime = (pretime / 60) - 1;
                else
                    minTime = (pretime / 60);

                string time = minTime.ToString("0") + ":" + secTime.ToString("00");
                timeText.text = time;
            }
            else
                timeText.text = pretime.ToString("0");
        }
        
        
        
}

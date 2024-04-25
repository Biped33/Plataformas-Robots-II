using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timer = 100;
    public bool GameOver = false;
    public bool timeIsRunning = true;
    float tiempotranscurrido;
    private Lives LivesCounter;

    private void Start()
    {
        LivesCounter = FindObjectOfType<Lives>();

    }


    void FixedUpdate()
    {
        if ( timeIsRunning == true)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                
                if(timer < 10)
                {
                    timerText.color = Color.red;
                }
                else
                {
                    timerText.color = Color.white;
                }
            }
        }
        else
        {
            GameOver = true;
            timer = 0;
            timeIsRunning = false;
            LivesCounter.RestLives();

        }
    }

    // Update is called once per frame
    void Update()
    {
        //timerText.text = timer.ToString();
        //    timerText.text = string.Format("{0}");
        //timer.ToString("N0");
        timerText.text = timer.ToString("N0");
    }
    
    
        
    
}

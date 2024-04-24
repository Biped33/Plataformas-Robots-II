using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class MinusTimer : MonoBehaviour
{
    private float timer = 100;
    [SerializeField] TextMeshProUGUI timerText;
    float tiempotranscurrido;
    public bool GameOver=false;
    public bool timeIsRunning = true;
    void Start()
    {
        timer = 333;
        
    }
    void FixedUpdate()
    {
        if (timeIsRunning == true)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                Debug.Log(timer);
            }
        }
        else
        {
            GameOver = true;
            timer = 0;
            timeIsRunning = false;
        }
    }
    
}
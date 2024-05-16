using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public float timer = 100;
    public bool GameOver = false;
    public bool timeIsRunning = true;
    private Lives LivesCounter;
    public PlayersManager playersManagerscr;

    private void Start()
    {
        LivesCounter = FindObjectOfType<Lives>();
        playersManagerscr = FindObjectOfType<PlayersManager>();
    }

    void FixedUpdate()
    {
        if (timeIsRunning)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;

                if (timer < 10)
                {
                    timerText.color = Color.red;
                }
                else
                {
                    timerText.color = Color.white;
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
    }

    void Update()
    {
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);


        if (timer < 0)
        {
            playersManagerscr.killPlayer();
        }

    }
}

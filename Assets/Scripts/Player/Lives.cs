using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.EventSystems.EventTrigger;

public class Lives : MonoBehaviour
{
    public TextMeshProUGUI LivesText;

    public float playerLives =3;
    //bool GameOver = false;

    private Timer timer;
    //private PlayersManager playerManager;


    void Start()
    {
        //GameOver = false;
        timer = FindObjectOfType<Timer>();
       // playerManager = new PlayersManager();


    }
    

    // Update is called once per frame
    void Update()
    {
        LivesText.text = playerLives.ToString("N0");

        if (playerLives <= 0)
        {
       //     GameOver = true;
            pauseStop();
        }
       // if (GameOver)
       /// {
          //  playerManager=GetComponent<PlayersManager>(noLivesBehabiour());
            

        //}
    }


    public void RestLives()
    {
        playerLives = playerLives -1;
    }
    public void SumLives()
    {
        playerLives = playerLives + 1;
    }


    void pauseStop()
    {
        if (playerLives == 0)
        {
                timer = GetComponent<Timer>();
        }

    }
}

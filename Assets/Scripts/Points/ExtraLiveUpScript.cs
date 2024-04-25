using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraLiveUpScript : MonoBehaviour
{
    private Lives LivesCounter;
    private PointsManager pointsManagerScr;



    void Start()
    {
        LivesCounter = FindObjectOfType<Lives>();
        pointsManagerScr = FindObjectOfType<PointsManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Extra Live +");
            //playerLives++;
            //Destroy(this.gameObject);

            LivesCounter.SumLives();
            //Destroy(collision.gameObject);
            pointsManagerScr.addPoints(50);

            Destroy(this.gameObject);


        }

    }
}

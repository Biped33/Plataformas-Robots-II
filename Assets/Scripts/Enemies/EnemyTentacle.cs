using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTentacle : MonoBehaviour
{
    public GameObject enemyTentacle;
    private PointsManager pointsManagerScr;
    public int EnemyTentacleHealth = 1;
    public float moveSpeed = 1f;
    private Transform player;


    void Start()
    {
        
        pointsManagerScr = FindObjectOfType<PointsManager>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (player != null)
        {

            Vector3 direction = (player.transform.position - transform.position);


            if (direction != Vector3.zero)
            {
                direction.Normalize();
            }


            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {


        if (EnemyTentacleHealth > 0)
        {
            if (collision.gameObject.CompareTag("Lazer"))
            {
                EnemyTentacleHealth--;
                Destroy(collision.gameObject);
            }
            
        }
        if (EnemyTentacleHealth <= 0)
        {
            Destroy(this.gameObject);
            pointsManagerScr.addPoints(3);

            //Add points
        }
    }
}

